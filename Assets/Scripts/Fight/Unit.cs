using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour,IDamagable {
	List<Resource> resources;
	List<Item> items;
	List<Ability> abilities;
	FightController controller;
	internal Vector2 coordinates;
	int hitpoints;
	internal bool ally;
	internal int actionPoints;
	internal Ability selectedAbility;
	
	
	public void Start() {
		controller = FindObjectOfType<FightController>();
		controller.RegisterUnit(this);
	}
	public void OnDestroy() {
		controller.UnregisterUnit(this);
	}


	public bool TakeDamage(int damage) {
		hitpoints -= damage;
		return true;
	}
	public bool CheckResources(List<Resource> cost) {
		bool flag = true;
		foreach(Resource needed in cost) {
			flag = false;
			foreach(Resource owned in resources) {
				if (needed.type == owned.type) {
					if (needed.quantity <= owned.quantity) {
						flag = true;
						break;
					}
					else {
						break;
					}
				}
			}
			if (!flag) break;
		}
		return flag;
	}
}
