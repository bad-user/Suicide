using UnityEngine;
using System.Collections;

public class ElectrictyController : MonoBehaviour {


	public void OnTriggerEnter2D(Collider2D coll){
		if (coll.tag == "Player") {
			Player.insatance.die ();
		}
	}
}
