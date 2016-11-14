using UnityEngine;
using System.Collections;

public class GroundStatus : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.tag == "Ground") {
			PlayerController.instance.setGrounded (true);
		}
	}

	void OnTriggerExit2D(Collider2D target){
		if (target.tag == "Ground") {
			PlayerController.instance.setGrounded (false);
		}
	}


}
