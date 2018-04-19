using UnityEngine;
using System.Collections;


public class Entrance : MonoBehaviour
{
    //public int Level;
    //public bool IsExit;
    //public bool IsUltimateExit;
    //public bool IsFirstEntrance;
    public string LevelToGo;
    public string exitPoint;
    private MovementPlayer thePlayer;
    void Start()
    {
        thePlayer = FindObjectOfType<MovementPlayer>();
    }
    private void OnConnectedToServer()
    {
        
    } 
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "Edward_0")
        {
            if (Input.GetKeyDown(KeyCode.E))
           {
                /* KtoryPoziom.IsExit = IsExit;
                 KtoryPoziom.KtoryLevel = Level;
                 KtoryPoziom.IsUltimateExit = IsUltimateExit;
                 KtoryPoziom.IsFirstEntrance = IsFirstEntrance;
                 //KtoryPoziom.LastKnownLocationX= 
                // KtoryPoziom.LastKnownLocationY = 1;
                */
             UnityEngine.SceneManagement.SceneManager.LoadScene(LevelToGo);
                thePlayer.startPoint = exitPoint;
            }
        }
    }
}