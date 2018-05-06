using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour {
    private static bool object_exists;
    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(gameObject);
        /*if (!object_exists)
        {
            object_exists = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }*/
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
