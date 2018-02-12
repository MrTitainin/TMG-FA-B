using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NPC_Dialog : MonoBehaviour {

    public GameObject dBox;
    public Text dText;
    public bool DialogActive;

    public string[] dialogLines;
    public int currentLine;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(DialogActive && Input.GetKeyDown(KeyCode.J)) {
            
            currentLine++;
        }
        if(currentLine>= dialogLines.Length)
        {
            dBox.SetActive(false);
            DialogActive = false;

            currentLine = 0;
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
    }
}
