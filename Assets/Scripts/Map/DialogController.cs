using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogController : MonoBehaviour {
	private float dialogDelay = 0.25f;
	public GameObject dBox;
    public Text dText;
    public bool dialogActive = false;
	public bool receiveInput = false;

    public string[] dialogLines;
    public int currentLine;
	
	internal DialogActivator wherefrom;

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
			currentLine++;
			Delay();
		}
	}
	public void End() {
		dBox.SetActive(false);
		dialogActive = false;
		FindObjectOfType<GameController>().EndCurrentDialog();
		wherefrom.Disload();
		currentLine = 0;
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
}
