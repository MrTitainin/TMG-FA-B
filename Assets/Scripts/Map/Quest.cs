using UnityEngine;
using System.Collections;

public class Quest : MonoBehaviour {
    public string questName;
    public bool active;
    public bool finished;
    public Quest required;
    private static bool questExists;

	void Start () {
        if (!questExists) {
            questExists = true;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }
	
	void Update () {
	
	}
}
