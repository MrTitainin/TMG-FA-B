using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//
//
//              Jak robi sie obiekty wirtualne?
//
//
public class QuestObject
{
    public string questName;

    enum Statuses
    {
        NotTaken = 0,
        Active,
        Finished
    };
    Statuses statusNow = Statuses.NotTaken;
    public List<string> requiredID=new List<string>();
    

    public bool changeLocationOnAccept;
    public string targetLocation;
    public string targetStartLocation;

    //
    //public int questNumber;

    public QuestManager theQM;

    void Start()
    {
       
    }

    void Update()
    {

    }

    public void StartQuest ()
    {

    }

    public void EndQuest()
    {
        // theQM.questsCompleted[questNumber] = true;
        statusNow = Statuses.Finished;
        //gameObject.SetActive(false);
    }
}
//---DUMP---
/* 
 * private static bool questExists;
 * // if (!questExists)
        {
            questExists = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
    //    }
 * 
 * 
 * 
 * */
