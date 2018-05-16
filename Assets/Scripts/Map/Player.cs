using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour {
	//initialization (static)
	public string startPoint;
	private static bool playerExists;

	//config (static)
	public List<KeyCode> upButton;
	public List<KeyCode> downButton;
	public List<KeyCode> leftButton;
	public List<KeyCode> rightButton;
	public List<KeyCode> dialogButton;
	public List<KeyCode> doorButton;
	public List<KeyCode> acceptQuestButton;
	public List<KeyCode> rejectQuestButton;

	//constant multipliers (static)
	public float playerSpeed = 2.0f;
	public float slowMultiplier = 0.9f;

	//state (dynamic)
	private float currentSpeed = 0.0f;
	private Vector3 movement = new Vector3();
	private bool interrupt; //should move be cancelled

	//import (static)
	private Rigidbody2D m_Rigidbody;
	private Collider2D m_Collider;
	private GameController mapController;


	void Start() {
		m_Rigidbody = GetComponent<Rigidbody2D>() as Rigidbody2D;
		m_Collider = GetComponent<Collider2D>();
		mapController = FindObjectOfType<GameController>();
		if (!playerExists) {
			playerExists = true;
			DontDestroyOnLoad(transform.gameObject);
		}
		else {
			Destroy(gameObject);
		}
	}

	//routine
	void Update() {
		interrupt = false;
		CheckIfMove();
		CheckIfInteraction();
		if (!interrupt) {
			Move();
		}
		else {
			movement = Vector3.zero;
			currentSpeed = 0f;
		}
	}
	void CheckIfMove() {
		Vector3 newMovement = new Vector3();
		newMovement += TryUpdateMove(upButton, Vector3.up);
		newMovement += TryUpdateMove(downButton, Vector3.down);
		newMovement += TryUpdateMove(leftButton, Vector3.left);
		newMovement += TryUpdateMove(rightButton, Vector3.right);
		newMovement.Normalize();
		if (newMovement.magnitude > 0) {
			movement = newMovement;
			currentSpeed = playerSpeed;
		}
		else {
			currentSpeed *= slowMultiplier;
		}
	}
	void CheckIfInteraction() {
		if (CheckLeftClick(ContinueDialog)) return;
		if (TryInteract(dialogButton, ContinueDialog)) return;
		if (TryInteract(acceptQuestButton, AcceptQuest)) return;
		if (TryInteract(rejectQuestButton, RejectQuest)) return;
		if (CheckLeftClick(OpenDialog)) return;
		if (TryInteract(dialogButton, OpenDialog)) return;
		if (mapController.currentDialog != null) {
			interrupt = true;
			return;
		}

		if (TryInteract(doorButton,UseDoor)) return;
	}

	//utilities
	Vector3 TryUpdateMove(List<KeyCode> keyList, Vector3 movement) {
		foreach (KeyCode element in keyList) {
			if (Input.GetKey(element)) {
				return movement;
			}
		}
		return Vector3.zero;
	}
	bool TryInteract(List<KeyCode> keyList,Interaction toExec) {
		bool pressed=false;
		foreach (KeyCode element in keyList) {
			if (Input.GetKey(element)) {
				pressed = true;
				break;
			}
		}
		if (pressed) {
			if (toExec()) return true;
			else return false;
		}
		else return false;
	}
	bool CheckLeftClick(Interaction toExec) {
		if (Input.GetMouseButtonDown(0)) {
			if (toExec()) return true;
			else return false;
		}
		else return false;
	}


	//executables
	void Move() {
		this.transform.Translate(movement * Time.deltaTime * currentSpeed, Space.World);
	}
	public delegate bool Interaction();
	bool UseDoor() {
		List<Entrance> possible = new List<Entrance>();
		foreach(Entrance door in mapController.doors) {
			if(door.GetComponent<Collider2D>().Distance(m_Collider).distance < door.activatorDistance) {
				possible.Add(door);
			}
		}
		if(possible.Count==0) return false;
		else {
			possible[0].Proceed();  //uses first one, we can change it later to use eg. closest one, but in general no two door areas should intersect and for it we have activatorDistance in every door
			return true;
		}
	}
	bool OpenDialog() {
		List<DialogActivator> possible = new List<DialogActivator>();
		foreach (DialogActivator dialog in mapController.dialogEntities) {
			if (dialog.GetComponent<Collider2D>().Distance(m_Collider).distance < dialog.activatorDistance) {
				possible.Add(dialog);
			}
		}
		if (possible.Count == 0) return false;
		else {
			possible[0].RunDialog();  //same as in UseDoor
			return true;
		}
	}
	bool ContinueDialog() {
		if (mapController.currentDialog == null) return false;
		else {
			mapController.currentDialog.Proceed();
			return true;
		}
	}
	bool AcceptQuest() {
		if (mapController.currentDialog == null) return false;
		else {
			return mapController.currentDialog.AcceptQuest();
		}
	}
	bool RejectQuest() {
		if (mapController.currentDialog == null) return false;
		else {
			return mapController.currentDialog.RejectQuest();
		}
	}
}

//---DUMP---

// Will rotate the ship to face the mouse.
/*void Rotation()
{
	// We need to tell where the mouse is relative to the
	// player
	Vector3 worldPos = Input.mousePosition;
	worldPos = Camera.main.ScreenToWorldPoint(worldPos);

	/*
	   * Get the differences from each axis (stands for
	   * deltaX and deltaY)

	float dx = this.transform.position.x - worldPos.x;
	float dy = this.transform.position.y - worldPos.y;

	// Get the angle between the two objects
	float angle = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;

	/*
	   * The transform's rotation property uses a Quaternion,
	   * so we need to convert the angle in a Vector
	   * (The Z axis is for rotation for 2D).

	Quaternion rot = Quaternion.Euler(new Vector3(0, 0, angle + 90));

	// Assign the ship's rotation
	this.transform.rotation = rot;
}*/
