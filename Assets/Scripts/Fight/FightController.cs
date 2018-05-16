using UnityEngine;
using System.Collections;

public class FightController : MonoBehaviour {
	public enum State {
		START,
		PLAYERCHOICE,
		ENEMYCHOICE,
		LOSE,
		WIN
	}

	private State currentState;

	void Start() {
		currentState = State.START;
	}

	void Update() {
		Debug.Log(currentState);
		switch (currentState) {
			case (State.START):
				//różne rzeczy na start
				break;
			case (State.PLAYERCHOICE):
				break;
			case (State.ENEMYCHOICE):
				break;
			case (State.LOSE):
				break;
			case (State.WIN):
				break;
		}
	}

	void OnGUI() {
		if (GUILayout.Button("NEXT STATE")) {
			if (currentState == State.START) {
				currentState = State.PLAYERCHOICE;
			}
			else if (currentState == State.PLAYERCHOICE) {
				currentState = State.ENEMYCHOICE;
			}
			else if (currentState == State.ENEMYCHOICE) {
				currentState = State.LOSE;
			}
			else if (currentState == State.LOSE) {
				currentState = State.WIN;
			}
			else if (currentState == State.WIN) {
				currentState = State.START;
			}

		}
	}
}
