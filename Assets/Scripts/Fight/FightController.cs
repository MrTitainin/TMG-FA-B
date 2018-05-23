using UnityEngine;
using System.Collections.Generic;

public class FightController : MonoBehaviour {
	private string[] ROW_SEPARATOR = { ";" };
	private string[] TILE_SEPARATOR = { "," };

	public enum TurnState {
		START,
		PLAYER,
		ENEMY,
		LOSE,
		WIN
	}
	public enum ChoiceState {
		NONE,
		UNIT,
		//CATEGORY,
		ABILITY,
		TARGET,
		ADDITIONAL,
		//CONFIRM
	}

	//state
	private TurnState phase;
	private ChoiceState state;
	private Unit selectedUnit;
	private Vector2 target;

	//registries
	public List<Unit> units;
	public List<BattleObject> objects;
	public List<Tile> tileset;

	//map
	Tile[,] map;
	public TextAsset mapFile;


	void Start() {
		ReadMap();
		phase = TurnState.START;
	}

	//routine
	void Update() {
		switch (phase) {
			case (TurnState.START):

				break;
			case (TurnState.PLAYER):
				CheckInteraction();
				break;
			case (TurnState.ENEMY):
				break;
			case (TurnState.LOSE):
				break;
			case (TurnState.WIN):
				break;
		}
	}
	
	void CheckInteraction() {
		if (Input.GetMouseButtonDown(1)) {
			switch (state) {
				case ChoiceState.NONE:
					foreach(Unit u in units) {
						if (u.ally) if (u.GetComponent<Collider2D>().bounds.Contains(Input.mousePosition)) {
								selectedUnit = u;
								OpenAbilities();
								break;
						}
					}
					break;
				case ChoiceState.UNIT:
					foreach (Unit u in units) {
						if (u.ally) if (u.GetComponent<Collider2D>().bounds.Contains(Input.mousePosition)) {
								selectedUnit = u;
								break;
							}
					}
					break;
				case ChoiceState.ABILITY:
				case ChoiceState.TARGET:
				case ChoiceState.ADDITIONAL:

					break;
			}
		}
		else if (Input.GetMouseButtonDown(0)) {
			switch (state) {
				case ChoiceState.NONE:
					break;
				case ChoiceState.UNIT:
					break;
				case ChoiceState.ABILITY:
					break;
				case ChoiceState.TARGET:
					break;
				case ChoiceState.ADDITIONAL:
					break;
			}
		}
	}

	void OpenAbilities() {

	}

	void CancelState() {
		state = ChoiceState.NONE;
		selectedUnit.selectedAbility = null;
		selectedUnit = null;
		target = new Vector2();
	}

	//registries handling
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

	//map reading
	private void ReadMap() {
		string mf = mapFile.ToString();
		string[] rows = mf.Split(ROW_SEPARATOR, System.StringSplitOptions.RemoveEmptyEntries);

		map = new Tile[rows[0].Split(TILE_SEPARATOR, System.StringSplitOptions.None).Length,rows.Length];
		for (int ii = 0; ii < rows.Length; ii++) {
			string[] tiles = rows[ii].Split(TILE_SEPARATOR, System.StringSplitOptions.None);
			for (int jj = 0; jj < tiles.Length; jj++) {
				map[jj,ii] = ConvertToTile(tiles[jj],jj,ii);
			}
		}
	}
	private Tile ConvertToTile(string s,int x,int y) {
		Tile r = tileset[0];
		foreach (Tile t in tileset) if (t.type == s) {
				r = t;
				break;
		}
		r.coordinates = new Vector2(x, y);
		r=Instantiate(r, new Vector3(x, y, 0f), Quaternion.identity);
		return r;
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
