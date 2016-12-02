using UnityEngine;
using System.Collections;

public class BigButton : Button {

	void Start(){
		_obstacls = GameObject.FindGameObjectsWithTag ("BigButton");
		_obstaclesStatus = false;
	}

	public void OnTriggerEnter2D(Collider2D coll){
		if (coll.tag == "Box") {
			base.OnTriggerEnter2D (coll);
		}
	}

	public void OnTriggerStay2D(Collider2D coll){
		if (coll.tag == "Box") {
			base.OnTriggerStay2D (coll);
		}
	}

	public void OnTriggerExit2D(Collider2D coll){
		if (coll.tag == "Box") {
			base.OnTriggerExit2D (coll);
		}
	}
}
