using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;//tylko do testow

public class QuestManager : MonoBehaviour {
    public QuestObject[] quests;
   // public bool[] questsCompleted;
    private static bool QuestManagerExists;
    public Text QText;
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
        LoadQuest();
       // questsCompleted = new bool[quests.Length];
    }

        // Update is called once per frame
        void Update () {
		
	}

    public void LoadQuest()
    {
        XmlTextReader xmlReader = new XmlTextReader("sample_quest.xml");
        while (xmlReader.Read())
        {
            switch (xmlReader.NodeType)
            {
                case XmlNodeType.Element:
                   // listBox1.Items.Add("<" + xmlReader.Name + ">");
                    break;
                case XmlNodeType.Text:
                    // listBox1.Items.Add(xmlReader.Value);
                    QText.text = xmlReader.Value;
                    break;
                case XmlNodeType.EndElement:
                    //listBox1.Items.Add("");
                    break;
            }
        }
    }
}
