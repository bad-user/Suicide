using UnityEngine;
using System.Collections;

public class DieZone : MonoBehaviour {

	public void OnTriggerEnter2D(Collider2D coll){
		if (coll.tag == "Player") {
			Debug.Log ("ggggggg");
			coll.gameObject.GetComponent<Player> ().die ();
		}
	}
}
