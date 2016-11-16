using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private bool _isFacingRight;
	private CharacterController2D _controller;
	private float _normalizedHorizontalSpeed;
	private SpriteRenderer _spriteRenderer;

	public float MaxSpeed = 8f;
	public float SpeedAccelerationOnGround = 10f;
	public float SpeedAccelerationInAir = 5f;


	public void Start(){
		_spriteRenderer = GetComponent<SpriteRenderer> ();
		_controller = GetComponent<CharacterController2D> ();
		_isFacingRight = !_spriteRenderer.flipX;
	}

	public void Update()
	{
		HandleInput ();

		var movementFactor = _controller.State.IsGrounded ? SpeedAccelerationOnGround : SpeedAccelerationInAir;
		_controller.SetHorizontalForce (Mathf.Lerp(_controller.Velocity.x, _normalizedHorizontalSpeed*MaxSpeed,movementFactor * Time.deltaTime));
	}

	private void HandleInput(){
		if (Input.GetKey (KeyCode.RightArrow)) {
			_normalizedHorizontalSpeed = 1;
			if (!_isFacingRight) {
				Flip ();
			}
		}
		else if(Input.GetKey(KeyCode.LeftArrow)){
			_normalizedHorizontalSpeed = -1;
			if (_isFacingRight) {
				Flip ();
			}
		}
		else{
			_normalizedHorizontalSpeed = 0;
		}

		if(_controller.CanJump && Input.GetKey(KeyCode.UpArrow)){
			_controller.Jump ();
		}
	}

	private void Flip(){
		_isFacingRight = _spriteRenderer.flipX;
		_spriteRenderer.flipX = !_spriteRenderer.flipX;
	}
}


