using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public static class KtoryPoziom
{
    public static int KtoryLevel;
    public static bool IsExit;
    public static bool IsUltimateExit;
    public static bool IsFirstEntrance;
    public static int LastKnownLocationX;
    public static int LastKnownLocationY;
};    
public class GameController : MonoBehaviour {
    private static GameController m_Instance; 
	
	void Start () {
        if (m_Instance == null)
        {
            m_Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
	}
	
	
	void Update () {
        if (Input.GetButton("Cancel"))
        {
            Application.Quit();
        }
	}
   // public static void NextLevel(string name);
  //  {
        
        /*
        if (KtoryPoziom.IsExit)
        {
            if (KtoryPoziom.IsUltimateExit)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - KtoryPoziom.KtoryLevel);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
        }
        else
        {
            if (KtoryPoziom.IsFirstEntrance)
            {
                KtoryPoziom.KtoryLevel--;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + KtoryPoziom.KtoryLevel);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }*/

   // }
}
