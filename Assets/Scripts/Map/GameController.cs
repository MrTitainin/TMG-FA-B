using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public static class KtoryPoziom {
    public static int levelNumber;
};    
public class GameController : MonoBehaviour {
    private static GameController m_Instance;

	//registries
	[HideInInspector]
	public List<Entrance> doors;
	[HideInInspector]
	public List<DialogActivator> dialogEntities;
	public DialogController currentDialog;
	public List<bool> questList;

	//debug
	//public string id;

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

	public void RegisterDoor(Entrance newDoor) {
		doors.Add(newDoor);
	}
	public void RegisterDialogEntity(DialogActivator newDialogEntity) {
		dialogEntities.Add(newDialogEntity);
	}
	public void UnregisterDialogEntity(DialogActivator dialogEntity) {
		dialogEntities.Remove(dialogEntity);
	}
	public void NotifyDialog(DialogController newDialog) {
		currentDialog = newDialog;
	}
	public void EndCurrentDialog() {
		currentDialog = null;
	}
	public void NextScene(string nextScene) {
		FlushEntityRegistry();
		SceneManager.LoadScene(nextScene);
	}
	public void FlushEntityRegistry() {
		doors.Clear();
		dialogEntities.Clear();
	}
}

//---DUMP---
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
