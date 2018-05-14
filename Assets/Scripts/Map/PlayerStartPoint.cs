using UnityEngine;
using System.Collections;

public class PlayerStartPoint : MonoBehaviour {

    private Player thePlayer;
    private CameraFollow theCamera;

    public string pointName;
	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<Player>();
        if (thePlayer.startPoint == pointName)
        {
            thePlayer.transform.position = transform.position;

            theCamera = FindObjectOfType<CameraFollow>();
            theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
