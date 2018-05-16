using UnityEngine;
using System.Collections;


public class Entrance : MonoBehaviour {
    //dumped from here 1

	//specific data
    public string LevelToGo;
    public string exitPoint;
	public float activatorDistance = 10.0f;

    private Player thePlayer;
    void Start() {
        thePlayer = FindObjectOfType<Player>();
		FindObjectOfType<GameController>().RegisterDoor(this);
    }
	//dumped from here 3
    
	internal void Proceed() {
		FindObjectOfType<GameController>().NextScene(LevelToGo);
		FindObjectOfType<Player>().startPoint = exitPoint;
	}
}

//---DUMP---

//1
//public int Level;
//public bool IsExit;
//public bool IsUltimateExit;
//public bool IsFirstEntrance;

//2
/*KtoryPoziom.IsExit = IsExit;
KtoryPoziom.KtoryLevel = Level;
KtoryPoziom.IsUltimateExit = IsUltimateExit;
KtoryPoziom.IsFirstEntrance = IsFirstEntrance;
//KtoryPoziom.LastKnownLocationX= 
//KtoryPoziom.LastKnownLocationY = 1;
*/

//3
/*private void OnConnectedToServer() {
	 
}
void OnTriggerStay2D(Collider2D other) {
    if (other.name == "Edward_0") {
        if (Input.GetKeyDown(KeyCode.G)) {
			//dumped from here 2
			Proceed();
        }
    }
}*/
