using UnityEngine;
using System.Collections;

public class HiddenBox : MonoBehaviour {

	private GameObject[] _obstacls;

	void Start(){
		_obstacls = GameObject.FindGameObjectsWithTag ("HiddenBox");
	}

	public void OnTriggerEnter2D(Collider2D coll){
		for (int i = 0; i < _obstacls.Length; i++) {
			_obstacls [i].SetActive (false);
		}
	}

	public void OnTriggerExit2D(Collider2D coll){
		for (int i = 0; i < _obstacls.Length; i++) {
			_obstacls [i].SetActive (true);
		}
	}
}
