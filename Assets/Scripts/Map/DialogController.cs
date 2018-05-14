using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogController : MonoBehaviour {
	private float dialogDelay = 0.25f;

	public GameObject dBox;
    public Text dText;
	public Text qText;

    public bool dialogActive = false;
	public bool receiveInput = false;

    public string[] dialogLines;
    public int currentLine;

	public GameObject quest;
	public bool shouldGiveQuest;
	public int questLine=-1;
	public Quest givenQuest;

	private Player thePlayer;
	internal DialogActivator wherefrom;

	public bool changeLocationAtDialogEnd;
	public string targetLocation;
	public string targetStartPoint;

	void Start () {
		
	}

	void Update () {
		/*if(dialogActive && Input.GetKeyDown(KeyCode.J)) {
			Proceed();
        }*/
		if (dialogActive == false) return;
		if (currentLine >= dialogLines.Length) {
			End();
		}
		else dText.text = dialogLines[currentLine];
	}
	public void Run() {
		currentLine = 0;
		ShowDialog();
		Delay();
	}
	public void Proceed() {
		if (receiveInput) {
			if (!shouldGiveQuest || currentLine != questLine) {
				currentLine++;
				Delay();
			}
		}
	}
	public bool AcceptQuest() {
		//te komentarze chyba coś psują
		if (receiveInput && shouldGiveQuest && currentLine == questLine) {
			//quest.SetActive(true);
			givenQuest.active = true;
			//qText.text = givenQuest.questName;
			currentLine++;
			if (givenQuest.changeLocationOnAccept) {
				End();
				ChangeLocation(givenQuest.targetLocation, givenQuest.targetStartLocation);
			}
			return true;
		}
		else return false;
	}
	public bool RejectQuest() {
		if (receiveInput && shouldGiveQuest && currentLine == questLine) {
			currentLine++;
			return true;
		}
		else return false;
	}
	public void End() {
		dBox.SetActive(false);
		dialogActive = false;
		FindObjectOfType<GameController>().EndCurrentDialog();
		wherefrom.Disload();
		currentLine = 0;
		if (changeLocationAtDialogEnd) {
			ChangeLocation(targetLocation, targetStartPoint);
		}
	}
    public void ShowBox(string dialog)
    {
        dialogActive = true;
        dBox.SetActive(true);
        dText.text = dialog;
    }
    public void ShowDialog()
    {
        dialogActive = true;
        dBox.SetActive(true);
    }

	public void Delay() {
		receiveInput = false;
		StartCoroutine(CreateDelay(dialogDelay));
	}
	IEnumerator CreateDelay(float time) {
		yield return new WaitForSeconds(time);
		receiveInput = true;
	}
	public void QuestAktivator(Quest q) {
		quest.SetActive(true);
	}
	public void ChangeLocation(string location,string exitPoint) {
		FindObjectOfType<GameController>().NextScene(location);
		FindObjectOfType<Player>().startPoint = exitPoint;
	}
}
