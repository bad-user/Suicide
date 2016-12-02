using UnityEngine;
using System.Collections;

public class Spring : MonoBehaviour {

	public float JumpMagnitude = 20f;

	public void ControllerEnter2D(CharacterController2D ch){
		ch.SetVerticalForce (JumpMagnitude);
	}
}
