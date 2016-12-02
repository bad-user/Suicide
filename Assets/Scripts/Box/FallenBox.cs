using UnityEngine;
using System.Collections;

public class FallenBox : BoxController
{

	private bool _collideDownWithPlayer;
	private bool[] _collideDownWithNotPlayer;

	void Start ()
	{
		_collideDownWithNotPlayer = new bool[10];
		for (int i = 0; i < _collideDownWithNotPlayer.Length; i++) {
			_collideDownWithNotPlayer [i] = false;
		}
	}

	public void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "SmallButton" || coll.gameObject.tag == "Bullet")
			return;
		if (coll.transform.position.y < transform.position.y && coll.gameObject.tag == "Player") {
			_collideDownWithPlayer = true;
		} else {
			for (int i = 0; i < _collideDownWithNotPlayer.Length; i++) {
				if (_collideDownWithNotPlayer [i] == false) {
					_collideDownWithNotPlayer [i] = true;
					break;
				}
			}
		}

		bool collideNotPlayer = false;
		for (int i = 0; i < _collideDownWithNotPlayer.Length; i++) {
			if (_collideDownWithNotPlayer [i] == true) {
				collideNotPlayer = true;
				break;
			}
		}

		if (_collideDownWithPlayer && !collideNotPlayer) {
			if (Player.insatance.IsAlive) {
				Player.insatance.die ();
			}
		}

	}

	//	public void OnCollisionStay2D(Collision2D coll){
	//		bool collideNotPlayer = false;
	//		for (int i = 0; i < _collideDownWithNotPlayer.Length; i++) {
	//			if (_collideDownWithNotPlayer [i] == true) {
	//				collideNotPlayer = true;
	//				break;
	//			}
	//		}
	//		Debug.Log (_collideDownWithPlayer + "///" + collideNotPlayer);
	//		if (_collideDownWithPlayer && !collideNotPlayer) {
	//			if (Player.insatance.IsAlive) {
	//				Player.insatance.die ();
	//			}
	//		}
	//	}

	public void OnCollisionExit2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "SmallButton" || coll.gameObject.tag == "Bullet")
			return;
		if (coll.transform.position.y < transform.position.y && coll.gameObject.tag == "Player") {
			_collideDownWithPlayer = false;
		} else {
			for (int i = 0; i < _collideDownWithNotPlayer.Length; i++) {
				if (i == _collideDownWithNotPlayer.Length - 1 && _collideDownWithNotPlayer [i] == true) {
					_collideDownWithNotPlayer [i] = false;
					break;
				}
				if (_collideDownWithNotPlayer [i] == true && _collideDownWithNotPlayer [i + 1] == false) {
					_collideDownWithNotPlayer [i] = false;
					break;
				}
			}
		}
	}
}
