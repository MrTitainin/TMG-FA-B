using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour {
	public enum AbilityType {
		GATHER,
		ATTACK,
		CREATE,
		CRAFT
	}
	public List<Resource> cost;
	public int actionCost;
	public string abilityName;
	public AbilityType action;
	//common
	public double range;
	public Texture2D icon;
	//attack
	public int damage;

	public void Select(Unit source) {

	}
	public bool Perform(Unit source,Vector2 coordinates) {
		if (source.CheckResources(cost)&&source.actionPoints>=actionCost) {
			FightController controller = FindObjectOfType<FightController>();
			bool actionSuccesful=false;
			switch (action) {
				case AbilityType.GATHER:
					break;
				case AbilityType.ATTACK:
					Unit target;
					foreach(Unit possibleTarget in controller.units) {
						if (coordinates == possibleTarget.coordinates) {
							if (possibleTarget.ally != source.ally) {
								target = possibleTarget;
								actionSuccesful = true;
								break;
							}
						}
					}
					break;
				case AbilityType.CREATE:
					break;
				case AbilityType.CRAFT:
					break;

			}
			return actionSuccesful;
		}
		else return false;
	}
}
