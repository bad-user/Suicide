using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


	public static PlayerController instance;

	public Animator anim;

	private bool isGrounded = true;
	private bool moving = false;

	private bool movingForward = false;
	private bool movingBack = false;

	public float speed = 3f;
	public float jumpSpeed = 7f;
	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (movingForward) {
			MoveForward ();
			moving = true;
		} 
		else if (movingBack) {
			MoveBack();
			moving = true;
		} else {
			moving = false;
		}

		if (Input.GetKey (KeyCode.UpArrow) && isGrounded) {
			Jump ();
		}

		if (moving) {
			StartAnimation ();
		} else {
			StopAnimation ();
		}
	}

	private void MoveForward(){
		Vector2 temp = transform.position;
		temp.x += Time.deltaTime * speed;
		transform.position = temp;
		RightDirection ();
	}

	private void MoveBack(){
		Vector2 temp = transform.position;
		temp.x -= Time.deltaTime * speed;
		transform.position = temp;
		LeftDirection ();
	}

	public void Jump(){
		isGrounded = false;
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, 1f) * jumpSpeed;
	}

	public void setGrounded(bool status){
		isGrounded = status;
	}

	private void RightDirection(){
		GetComponent<SpriteRenderer> ().flipX = false;
	}

	private void LeftDirection (){
		GetComponent<SpriteRenderer> ().flipX = true;
	}

	private void StartAnimation(){
		anim.speed = 1;
		anim.SetBool ("Running", true);
	}

	private void StopAnimation(){
		anim.speed = 100;
		anim.SetBool ("Running", false);
	}

	public void MoveRight(){
		movingForward = true;
	}

	public void StopMovingRight(){
		movingForward = false;
	}

	public void MovingLeft(){
		movingBack = true;
	}

	public void StopMovingLeft(){
		movingBack = false;
	}
}
