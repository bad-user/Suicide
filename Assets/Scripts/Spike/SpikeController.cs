using UnityEngine;
using System.Collections;

public class SpikeController : MonoBehaviour {

	public void ControllerEnter2D(CharacterController2D controller){
		Debug.Log ("Hello");
		Player p = controller.gameObject.GetComponent<Player> ();
		p.die ();
	}
}
