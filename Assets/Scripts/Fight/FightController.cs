using UnityEngine;
using System.Collections.Generic;
using System;

public class FightController : MonoBehaviour {
	private readonly string[] ROW_SEPARATOR = { ";" };
	private readonly string[] TILE_SEPARATOR = { "," };
	public bool useHexagonalCirclesLayout=true;
	public AbilityCircle abilityCirclePrefab;

	public enum TurnState {
		START,
		PLAYER,
		ENEMY,
		LOSE,
		WIN
	}
	public enum ChoiceState {
		UNIT,
		ACTION,
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
	public List<AbilityCircle> circles;

	//map
	Tile[,] map;
	public TextAsset mapFile;


	void Start() {
		ReadMap();
		phase = TurnState.PLAYER;
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
		Vector3 clickpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		clickpos.z = 0.0f;
		if (Input.GetMouseButtonDown(1)) {
			switch (state) {
				case ChoiceState.UNIT:
					Debug.Log("interaction");
					foreach (Unit u in units) {
						if (u.ally) {
							Debug.Log("found ally");
							Debug.Log(u.GetComponent<Collider2D>().bounds.min);
							Debug.Log(u.GetComponent<Collider2D>().bounds.max);
							Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
							if (u.GetComponent<Collider2D>().bounds.Contains(clickpos)) {
								Debug.Log("ally in range");
								selectedUnit = u;
								OpenAbilities();
								break;
							}
						}
					}
					break;
				case ChoiceState.ACTION:
					bool found = false;
					foreach (Unit u in units) {
						if (u.ally) if (u.GetComponent<Collider2D>().bounds.Contains(Input.mousePosition)) {
							found = true;
							selectedUnit = u;
							break;
						}
					}
					if (found) OpenAbilities();
					else CancelState();
					break;
				case ChoiceState.ABILITY:
				case ChoiceState.TARGET:
				case ChoiceState.ADDITIONAL:
					CancelState();
					break;
			}
		}
		else if (Input.GetMouseButtonDown(0)) {
			switch (state) {
				case ChoiceState.UNIT:
					foreach (Unit u in units) {
						if (u.ally) if (u.GetComponent<Collider2D>().bounds.Contains(Input.mousePosition)) {
								selectedUnit = u;
								UnitSelected();
								break;
							}
					}
					break;
				case ChoiceState.ACTION:
					//tile
					break;
				case ChoiceState.ABILITY:
					//separate event in AbilityCircle
					break;
				case ChoiceState.TARGET:
					//tile
					break;
				case ChoiceState.ADDITIONAL:
					//there will be separate event
					break;
			}
		}
	}

	void UnitSelected() {
		state = ChoiceState.ACTION;
	}

	public void AbilitySelected() {
		state=ChoiceState.TARGET;
	}

	void OpenAbilities() {
		Debug.Log("abilities");
		Resources.Load("");
		state = ChoiceState.ABILITY;
		int parts = selectedUnit.abilities.Count;
		Vector2 cpos = selectedUnit.coordinates;
		double currentAngle = Math.PI / 2.0;
		if (useHexagonalCirclesLayout) {
			if (parts <= 6) {
				double angleDifference = (2.0 * Math.PI) / parts;
				for (int ii = 0; ii < parts; ii++) {
					AbilityCircle c = Instantiate(abilityCirclePrefab, new Vector3((float)Math.Cos(currentAngle)+cpos.x, (float)Math.Sin(currentAngle)+cpos.y), Quaternion.identity);
					circles.Add(c);
					c.Assign(selectedUnit, selectedUnit.abilities[ii]);
					currentAngle -= angleDifference;
				}
			}
			else {
				double angleDifference = Math.PI / 3.0;
				int sn = 0;
				int seqTreshold = 0;
				int lineTreshold = 0;
				Vector3 lineStartpoint = new Vector3(0f,0f,0f);
				Vector3 lineEndpoint = new Vector3(0f,0f,0f);
				for (int ii = 0; ii < parts; ii++) {
					if (ii == lineTreshold+sn) {
						lineTreshold += sn;
						if (lineTreshold == seqTreshold) {
							sn++;
							seqTreshold += 6 * sn;
							currentAngle = Math.PI / 6.0;
							lineStartpoint = new Vector3(0f, sn);
						}
						else {
							lineStartpoint = lineEndpoint;
							currentAngle -= angleDifference;
						}
						lineEndpoint = new Vector3(sn*(float)Math.Cos(currentAngle), sn*(float)Math.Sin(currentAngle));
					}
					AbilityCircle c = Instantiate(abilityCirclePrefab,(new Vector3(cpos.x,cpos.y))+Vector3.Lerp(lineStartpoint,lineEndpoint,(ii-lineTreshold)/sn), Quaternion.identity);
					circles.Add(c);
					c.Assign(selectedUnit, selectedUnit.abilities[ii]);
				}
			}
		}
		else {
			double angleDifference = (2.0 * Math.PI) / parts;
			float radius = parts>6 ? 0.5f/(float)Math.Sin(Math.PI/parts) : 1.0f;
			for (int ii = 0; ii < parts; ii++) {
				AbilityCircle c = Instantiate(abilityCirclePrefab, new Vector3(radius*(float)Math.Cos(currentAngle) + cpos.x, radius*(float)Math.Sin(currentAngle) + cpos.y), Quaternion.identity);
				circles.Add(c);
				c.Assign(selectedUnit, selectedUnit.abilities[ii]);
				currentAngle -= angleDifference;
			}
		}
	}

	void CancelState() {
		state = ChoiceState.UNIT;
		selectedUnit.selectedAbility = null;
		selectedUnit = null;
		target = new Vector2();
		foreach(AbilityCircle c in circles) {
			Destroy(c);
		}
		circles.Clear();
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

		map = new Tile[rows[0].Split(TILE_SEPARATOR, System.StringSplitOptions.None).Length, rows.Length];
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
