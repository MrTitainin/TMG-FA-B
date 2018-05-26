using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuestObject : MonoBehaviour
{
    public string questName;

    public bool active;
    //public bool finished;
    public List<string> requiredID=new List<string>();
    

    public bool changeLocationOnAccept;
    public string targetLocation;
    public string targetStartLocation;

    //
    public int questNumber;

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
        theQM.questsCompleted[questNumber] = true;
        gameObject.SetActive(false);
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
