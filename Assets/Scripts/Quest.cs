using UnityEngine;
using System.Collections;

public class Quest : MonoBehaviour {
    public string nazwa_questa;
    public bool czy_quest_aktywny;
    public bool czy_quest_ukonczony;
    public Quest quest_wymagany;
    private static bool quest_exists;

	// Use this for initialization
	void Start () {
        

        if (!quest_exists)
        {
            quest_exists = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
