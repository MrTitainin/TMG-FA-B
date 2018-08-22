﻿using UnityEngine;
using System.Collections;

public class QuestObject : MonoBehaviour
{
    public string questName;
    public bool active;
    public bool finished;
    public QuestObject required;
    private static bool questExists;

    public bool changeLocationOnAccept;
    public string targetLocation;
    public string targetStartLocation;

    //
    public int questNumber;

    public QuestManager theQM;

    void Start()
    {
        if (!questExists)
        {
            questExists = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {

    }

    public void StartQuest ()
    {

    }

    public void EndQuest()
    {
        theQM.questsCompleted[questNumber] = true;
        gameObject.SetActive(false);
    }
}