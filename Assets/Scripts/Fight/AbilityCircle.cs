﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCircle : MonoBehaviour {
	Ability ability;
	Unit source;
	internal void Assign(Unit u, Ability a) {
		ability = a;
		source = u;
	}
	void Start () {
		transform.gameObject.layer = 5;
	}
	
	void Update () {
		
	}

	//when hovered
	private void OnMouseOver() {
		//tooltip later
	}

	//when pressed
	private void OnMouseUpAsButton() {
		ability.Select(source);
		FindObjectOfType<FightController>().AbilitySelected();
	}
}