using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public GameObject m_Target;
    private static bool cameraExists;
	// Use this for initialization
	void Start () {
        if (!cameraExists)
        {
            cameraExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        

    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(m_Target.transform.position.x,
                                m_Target.transform.position.y,
                                transform.position.z);
	}
}
