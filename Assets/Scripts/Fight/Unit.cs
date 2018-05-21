using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour,IDamagable {
	public bool DealDamage(int damage) {
		return false;
	}
	FightController controller;
	public void Start() {
		controller = FindObjectOfType<FightController>();
		controller.RegisterUnit(this);
	}
	public void OnDestroy() {
		controller.UnregisterUnit(this);
	}
}
