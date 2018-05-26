using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCircle : MonoBehaviour {
	Ability ability;
	Unit source;
	void Start () {
		
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
