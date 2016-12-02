using UnityEngine;
using System.Collections;

public class ElecButton : MonoBehaviour {

	private GameObject[] _elecBoxs;
	private bool _elecStatus;

	// Use this for initialization
	void Start () {
		_elecBoxs = GameObject.FindGameObjectsWithTag ("ElecButton");
		_elecStatus = false;
		for (int i = 0; i < _elecBoxs.Length; i++) {
			_elecBoxs [i].SetActive (_elecStatus);
		}
	}

	public void OnTriggerEnter2D(Collider2D coll){
		_elecStatus = !_elecStatus;
		for (int i = 0; i < _elecBoxs.Length; i++) {
			_elecBoxs [i].SetActive (_elecStatus);
		}
	}
		
	

}
