using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	private Text _text;

	public void Awake(){
		_text = GetComponent<Text> ();
		_text.text = "Level " + GameController.instance.GetCurrentLevel ();
	}

}
