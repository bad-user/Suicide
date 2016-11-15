using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


	public static PlayerController instance;

	public Animator anim;

	private bool isGrounded = true;
	private bool moving = false;
	private bool isAlive = false;

	private bool movingForward = false;
	private bool movingBack = false;
	private bool jump = false;

	public float speed = 3f;
	public float jumpSpeed = 7f;
	public float offset = 0.2f;

	[SerializeField]
	private BoxCollider2D boxCollider;

	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
			isAlive = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (isAlive) {
			if (movingForward || Input.GetKey (KeyCode.RightArrow)) {
				MoveForward ();
				moving = true;
			} else if (movingBack || Input.GetKey (KeyCode.LeftArrow)) {
				MoveBack ();
				moving = true;
			} else {
				moving = false;
			}

			if ((jump || Input.GetKey (KeyCode.UpArrow)) && isGrounded) {
				Jump ();
			}

			if (moving) {
				StartAnimation ();
			} else {
				StopAnimation ();
			}
		}
	}

	private void MoveForward(){
		Vector2 temp = transform.position;
		temp.x += Time.deltaTime * speed;
		transform.position = temp;
		RightDirection ();
		moveOffestForCollider (offset);
	}

	private void MoveBack(){
		Vector2 temp = transform.position;
		temp.x -= Time.deltaTime * speed;
		transform.position = temp;
		LeftDirection ();
		moveOffestForCollider (-offset);
	}

	public void jumpbtn(){
		jump = true;
	}

	private void Jump(){
		jump = false;
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

	public void setAlive(bool status){
		isAlive = status;
	}

	public bool IsAlive(){
		return isAlive;
	}


	private void moveOffestForCollider(float offest){
		boxCollider.offset = new Vector2 (offest, 0f);
	}

	public void die(){
		isAlive = false;
		anim.speed = 10f;
		anim.SetTrigger ("Die");
		GameController.instance.NextLevel ();
	}


}
