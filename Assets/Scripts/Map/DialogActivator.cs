using UnityEngine;
using System.Collections.Generic;

public class DialogActivator : MonoBehaviour {

    public string tekscik;
    private DialogController npc;
	public string[] dialogLines;
	public float activatorDistance;
	public bool oneTimeOnly;

	public bool isQuest;
	public int questLine;
	public int questCount;
	public List<Quest> quests;

	public bool changeLocationAtDialogEnd;
	public string targetLocation;
	public string startPoint;

	void Start () {
        npc = FindObjectOfType<DialogController>();
		FindObjectOfType<GameController>().RegisterDialogEntity(this);
	}

	void Update () {
	
	}  
	internal void RunDialog() {
		if (!npc.dialogActive) {
			npc.dialogLines = dialogLines;
			npc.wherefrom = this;
			npc.Run();
			npc.changeLocationAtDialogEnd = changeLocationAtDialogEnd;
			npc.targetLocation = targetLocation;
			npc.targetStartPoint = startPoint;
			if (isQuest) {
				npc.shouldGiveQuest = true;
				npc.questLine = questLine;
				foreach(Quest q in quests) {
					if (!q.finished) {
						print(q.questName);
						npc.givenQuest = q;
						break;
					}
				}
			}
			FindObjectOfType<GameController>().NotifyDialog(npc);
		}
	}
	internal void DisloadDialog() {
		if(oneTimeOnly) FindObjectOfType<GameController>().UnregisterDialogEntity(this);
	}
}

//---DUMP---
/*void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.name== "PlayerEdward") {
            if (Input.GetKeyUp(KeyCode.J)) {
                //Npc.ShowBox(tekscik);
				if(!npc.dialogActive) {
                    npc.dialogLines = dialogLines;
                    npc.currentLine = 0;
                    npc.ShowDialog();
                }
            }
        }
    }*/