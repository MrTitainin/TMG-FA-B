using UnityEngine;
using System.Collections;

public class DialogAktywacja : MonoBehaviour {

    public string tekscik;
    private NPC_Dialog Npc;
    public bool isQuest;
    public int Quest_W_Ktorej_Linii;
    public string[] dialogLines;
    public int ile_questow;
    public Quest[] questy;

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
                if (Input.GetKeyUp(KeyCode.E))
                {
                    //Npc.ShowBox(tekscik);
                    if(isQuest)
                {
                    Npc.czy_ma_dac_quest = true;
                    Npc.linia_questu = Quest_W_Ktorej_Linii;
                }
                    if (!Npc.DialogActive)
                    {
                        Npc.dialogLines = dialogLines;
                    if (isQuest)
                    {
                        for (int i = 0; i < ile_questow; i++)
                        {
                            if (!questy[i].czy_quest_ukonczony)
                            {
                                Npc.zlecanyQuest = questy[i];
                                break;
                            }
                        }
                    }
                        Npc.currentLine = 0;
                        Npc.ShowDialog();
                    }
                }
            }
        }
   
}
