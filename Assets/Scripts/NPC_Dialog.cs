using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NPC_Dialog : MonoBehaviour {

    public GameObject dBox;
    public Text dText;
    public bool DialogActive;

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
            
            currentLine++;
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
}
