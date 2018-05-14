using UnityEngine;
using System.Collections;

public class DialogActivator : MonoBehaviour {

    public string tekscik;
    private DialogController npc;
    public string[] dialogLines;
	public float activatorDistance;
	public bool oneTimeOnly;

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
			FindObjectOfType<GameController>().NotifyDialog(npc);
		}
	}
	internal void Disload() {
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