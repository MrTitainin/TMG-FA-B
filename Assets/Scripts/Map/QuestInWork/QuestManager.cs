using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {
    public QuestObject[] quests;
    public bool[] questsCompleted;
	// Use this for initialization
	void Start () {
        questsCompleted = new bool[quests.Length];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void showQuest()
    {

    }
}
