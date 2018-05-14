using UnityEngine;
using System.Collections;

public class WalkaStatystyki : MonoBehaviour {

    public enum StanyWalka
    {
        START,
        PLAYERCHOICE,
        ENEMYCHOICE,
        LOSE,
        WIN
    }

    private StanyWalka ObecnyStan;
	// Use this for initialization
	void Start () {
        ObecnyStan = StanyWalka.START;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(ObecnyStan);
        switch (ObecnyStan)
        {
            case (StanyWalka.START):
                //różne rzeczy na start
                    break;
            case (StanyWalka.PLAYERCHOICE):
                    break;

            case (StanyWalka.ENEMYCHOICE):
                    break;
            case (StanyWalka.LOSE):
                    break;
            case (StanyWalka.WIN):
                    break;
        }
	}
    void OnGUI()
    {
        if (GUILayout.Button("NEXT STATE"))
        {
            if (ObecnyStan == StanyWalka.START)
            {
                ObecnyStan = StanyWalka.PLAYERCHOICE;
            }else if (ObecnyStan == StanyWalka.PLAYERCHOICE)
            {
                ObecnyStan = StanyWalka.ENEMYCHOICE;
            }else if (ObecnyStan == StanyWalka.ENEMYCHOICE)
            {
                ObecnyStan = StanyWalka.LOSE;
            }else if (ObecnyStan == StanyWalka.LOSE)
            {
                ObecnyStan = StanyWalka.WIN;
            }else if (ObecnyStan == StanyWalka.WIN)
            {
                ObecnyStan = StanyWalka.START;
            }

        }
    }
}
