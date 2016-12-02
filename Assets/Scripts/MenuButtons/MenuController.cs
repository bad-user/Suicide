using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {
	public static MenuController instance;

	public Sprite ActivedSprite, DeactivedSprite;

	public void Start(){
		if (instance == null) {
			instance = this;
			GameController.instance.InitMenuLevels ();
		}
	}
}
