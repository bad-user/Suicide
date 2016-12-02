using UnityEngine;
using System.Collections;

public class SmallButton : Button {

	void Start(){
		_obstacls = GameObject.FindGameObjectsWithTag ("SmallButton");
		_obstaclesStatus = false;
	}
}
