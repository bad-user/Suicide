using UnityEngine;
using System.Collections;

public class BoxController : MonoBehaviour {

	public Vector2 VelocityToMove{ get; set;}


	private Transform _transform;

	public void Awake(){
		_transform = GetComponent<Transform> ();
	}

	public void Update(){
		
	}

	public void onPlayerCollide(CharacterController2D controller){
		VelocityToMove = controller.Velocity;
		_transform.Translate (VelocityToMove * Time.deltaTime / 1.5f);
	}

	public void OnCollisionEnter2D(Collision2D coll){
		if (coll.collider.tag == "Player") {
			return;
		}
		_transform.localEulerAngles = new Vector3 (0,0,0);
	}
}
