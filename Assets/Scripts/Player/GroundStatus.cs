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
		if (PlayerController.instance.IsAlive()) {
			if (target.tag == "Ground") {
				PlayerController.instance.setGrounded (true);
			} else if (target.tag == "Spikes") {
				PlayerController.instance.die ();
			}
		}
	}

	void OnTriggerExit2D(Collider2D target){
		if (PlayerController.instance.IsAlive ()) {
			if (target.tag == "Ground") {
				PlayerController.instance.setGrounded (false);
			}
		}
	}


}
