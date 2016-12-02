using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	protected GameObject[] _obstacls;
	protected bool _obstaclesStatus;



	public void OnTriggerEnter2D(Collider2D coll){
		ObstaclesStatus (false);
	}

	public void OnTriggerStay2D(Collider2D coll){
		if (_obstaclesStatus != false) {
			ObstaclesStatus (false);
		}
	}

	public void OnTriggerExit2D(Collider2D coll){
		ObstaclesStatus (true);
	}

	private void ObstaclesStatus(bool status){
		for (int i = 0; i < _obstacls.Length; i++) {
			_obstacls [i].SetActive (status);
		}
		_obstaclesStatus = status;
	}
}
