using UnityEngine;
using System.Collections.Generic;

public class FightController : MonoBehaviour {
	public enum State {
		START,
		PLAYERCHOICE,
		ENEMYCHOICE,
		LOSE,
		WIN
	}

	private State currentState;

	public List<Unit> units;
	public List<BattleObject> objects;


	void Start() {
		currentState = State.START;
	}

	void Update() {
		switch (currentState) {
			case (State.START):
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
	
	public void RegisterObject(BattleObject b) {
		objects.Add(b);
	}

	public void UnregisterObject(BattleObject b) {
		objects.Remove(b);
	}

	public void RegisterUnit(Unit b) {
		units.Add(b);
	}
	public void UnregisterUnit(Unit b) {
		units.Remove(b);
	}
}

//---DUMP---
/*
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
}*/
