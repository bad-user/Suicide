using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Controllers : MonoBehaviour {

	public Sprite ActivedSound, DeactivedSound;
	private Image _imageComponentOfMuteSound;

	void Awake(){
		_imageComponentOfMuteSound = GameObject.Find ("MuteSound").GetComponent<Image>();
		bool isSoundActive = GameController.instance.IsSoundActive ();
		if (!isSoundActive) {
			_imageComponentOfMuteSound.sprite = DeactivedSound;
		}
			
	}

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

	public void Fire(){
		Player.insatance.Fire ();
	}

	public void Restart(){
		GameController.instance.RestartLevel ();
	}

	public void GoToMenu(){
		GameController.instance.GoToMenu ();
	}

	public void ToggleSound(){
		GameController.instance.ToggleSound ();

		if (GameController.instance.IsSoundActive())
			_imageComponentOfMuteSound.sprite = ActivedSound;
		else
			_imageComponentOfMuteSound.sprite = DeactivedSound;

	}
}
