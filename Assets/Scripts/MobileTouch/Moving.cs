using UnityEngine;
using System.Collections;

public class Moving : MonoBehaviour {

	public void MoveRight(){
		Player.insatance.MoveRight ();
	}

	public void MoveLeft(){
		Player.insatance.MoveLeft ();
	}

	public void StopMovingRight(){
		Player.insatance.StopMovingRight ();
	}

	public void StopMovingLeft(){
		Player.insatance.StopMovingLeft ();
	}

	public void Jump(){
		Player.insatance.Jump ();
	}
}
