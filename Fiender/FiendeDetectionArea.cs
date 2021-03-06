﻿using UnityEngine;
using System.Collections;

public class FiendeDetectionArea : MonoBehaviour {

	private FiendeAngrep fiendeAngrep;
	private Transform target;
	// Use this for initialization
	
	//Finner skripet i hirarkiet
	void Awake (){
		fiendeAngrep = gameObject.GetComponentInParent<FiendeAngrep> ();
	}
	
	//Kommer fienden inn i detectionsonen settes targett til fiendenden som har kommet inn.
	//Fiender er alle som har taggen Enemy
	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "Forsvarselement" || other.gameObject.tag == "Landsby") {
			target = other.gameObject.transform;
			fiendeAngrep.Target(target, true);
		}
	}
	//Dersom fiendern forsvinner ut av detectionon sonen settes target til null
	void OnTriggerExit(Collider other){
		if (other.gameObject.transform.tag == "Forsvarselement") {
			fiendeAngrep.resetAngrip();;
		}
	}
}
