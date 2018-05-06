using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NPC_Dialog : MonoBehaviour {

    public GameObject dBox;
    public GameObject Nazwa_quest;
    public Text qText;
    public Text dText;
    public bool DialogActive;
    public bool czy_ma_dac_quest;
    public int linia_questu;
    public Quest zlecanyQuest;
    public string[] dialogLines;
    public int currentLine;
    private MovementPlayer thePlayer;
    private static bool czy_istnieje;

    
	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<MovementPlayer>();
     /*   if (!czy_istnieje)
        {
            czy_istnieje = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }*/
    }
	
	// Update is called once per frame
	void Update () {
        if (czy_ma_dac_quest)
        {
            if (DialogActive && Input.GetMouseButtonDown(0))
            {


                if (currentLine != linia_questu)
                {
                    currentLine++;
                }
            }
            if (DialogActive && currentLine == linia_questu)
            {
                if (Input.GetKeyDown(KeyCode.Y))
                {
                    Nazwa_quest.SetActive(true);
                    zlecanyQuest.czy_quest_aktywny = true;
                    qText.text = zlecanyQuest.nazwa_questa;
                    currentLine++;
                }
                else if (Input.GetKeyDown(KeyCode.N))
                {
                    currentLine++;
                }
            }
        }
        else
        {
            if (DialogActive && Input.GetMouseButtonDown(0))
            {
                    currentLine++;
            }
        }
        
        if(currentLine>= dialogLines.Length)
        {
            dBox.SetActive(false);
            DialogActive = false;

            currentLine = 0;
            thePlayer.canMove = true;
        }
        dText.text = dialogLines[currentLine];

    }
    public void ShowBox(string dialog)
    {
        DialogActive = true;
        dBox.SetActive(true);
        dText.text = dialog;
    }
    public void ShowDialog()
    {
        DialogActive = true;
        dBox.SetActive(true);
        thePlayer.canMove = false;
    }
    public void QuestAktywator(Quest quest)
    {
        Nazwa_quest.SetActive(true);
    }
}
