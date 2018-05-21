using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleObject : MonoBehaviour, IEntity {
	FightController controller;
	public void Start() {
		controller = FindObjectOfType<FightController>();
		controller.RegisterObject(this);
	}
	public void OnDestroy() {
		controller.UnregisterObject(this);
	}
}
