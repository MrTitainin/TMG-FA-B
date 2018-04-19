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

    public string[] dialogLines;
    public int currentLine;
    private MovementPlayer thePlayer;

    
	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<MovementPlayer>();
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(DialogActive && Input.GetMouseButtonDown(0)) {
            
            
            if(currentLine!=linia_questu&&czy_ma_dac_quest)
            {
                currentLine++;
            }
        }
        if(DialogActive && currentLine==linia_questu&&czy_ma_dac_quest)
            {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                Nazwa_quest.SetActive(true);
                currentLine++;
            }else if (Input.GetKeyDown(KeyCode.N))
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
    public void QuestAktywator(Questy quest)
    {
        Nazwa_quest.SetActive(true);
    }
}
