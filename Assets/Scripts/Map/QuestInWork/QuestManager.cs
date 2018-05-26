using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {
    public QuestObject[] quests;
    public bool[] questsCompleted;
    private static bool QuestManagerExists;
	// Use this for initialization
	void Start ()
    {
        
        if (!QuestManagerExists)
        {
            QuestManagerExists = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        questsCompleted = new bool[quests.Length];
    }

        // Update is called once per frame
        void Update () {
		
	}

    public void showQuest()
    {

    }
}
