using UnityEngine;
using System.Collections;

public class DialogAktywacja : MonoBehaviour {

    public string tekscik;
    private NPC_Dialog Npc;
    public string[] dialogLines;

	// Use this for initialization
	void Start () {
        Npc = FindObjectOfType<NPC_Dialog>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
   
     void OnTriggerStay2D(Collider2D other)
    {
            if (other.gameObject.name == "Edward_0")
            {
                if (Input.GetKeyUp(KeyCode.J))
                {
                    //Npc.ShowBox(tekscik);

                    if (!Npc.DialogActive)
                    {
                        Npc.dialogLines = dialogLines;
                        Npc.currentLine = 0;
                        Npc.ShowDialog();
                    }
                }
            }
        }
   
}
