using UnityEngine;
using System.Collections;

public class Quest : MonoBehaviour {
    public string questName;
    public bool active;
    public bool finished;
    public Quest required;
    private static bool questExists;

	public bool changeLocationOnAccept;
	public string targetLocation;
	public string targetStartLocation;

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
