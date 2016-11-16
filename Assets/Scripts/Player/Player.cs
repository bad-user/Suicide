using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	private bool _isFacingRight;
	private CharacterController2D _controller;
	private float _normalizedHorizontalSpeed;
	private SpriteRenderer _spriteRenderer;
	private BoxCollider2D _boxCollider;
	private Vector2 _defaultSizeOfCollider;
	private Vector2 _defaultoffsetOfCollider;
	private float _deltaColliderSize = 0.07f;

	public float MaxSpeed = 8f;
	public float SpeedAccelerationOnGround = 10f;
	public float SpeedAccelerationInAir = 5f;
	public Animator Anim;

	public void Awake ()
	{
		_boxCollider = GetComponent<BoxCollider2D> ();
		_spriteRenderer = GetComponent<SpriteRenderer> ();
		_controller = GetComponent<CharacterController2D> ();

		_defaultSizeOfCollider = _boxCollider.size;
		_defaultoffsetOfCollider = _boxCollider.offset;
	}

	public void Start ()
	{
		_isFacingRight = !_spriteRenderer.flipX;
	}

	public void Update ()
	{
		HandleInput ();

		var movementFactor = _controller.State.IsGrounded ? SpeedAccelerationOnGround : SpeedAccelerationInAir;
		_controller.SetHorizontalForce (Mathf.Lerp (_controller.Velocity.x, _normalizedHorizontalSpeed * MaxSpeed, movementFactor * Time.deltaTime));
	}

	private void HandleInput ()
	{
		if (Input.GetKey (KeyCode.RightArrow)) {
			_normalizedHorizontalSpeed = 1;
			RunningAnimation ();
			if (!_isFacingRight) {
				Flip ();
			}
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			_normalizedHorizontalSpeed = -1;
			RunningAnimation ();
			if (_isFacingRight) {
				Flip ();
			}
		} else {
			_normalizedHorizontalSpeed = 0;
			IdleAnimation ();
		}

		if (_controller.CanJump && Input.GetKey (KeyCode.UpArrow)) {
			_controller.Jump ();
		}
	}

	private void Flip ()
	{
		_isFacingRight = _spriteRenderer.flipX;
		_spriteRenderer.flipX = !_spriteRenderer.flipX;
	}

	private void RunningAnimation ()
	{

		Anim.speed = 1f;
		Anim.SetBool ("Running", true);
		Vector2 newColliderSize = _defaultSizeOfCollider;
		newColliderSize.x += _deltaColliderSize;
		_boxCollider.size = newColliderSize;

		Vector2 newColliderOffest = _defaultoffsetOfCollider;
		newColliderOffest.x += _deltaColliderSize;
		newColliderOffest.x *= (_isFacingRight ? 1 : -1);
		_boxCollider.offset = newColliderOffest;

	}

	private void IdleAnimation ()
	{
		Anim.SetBool ("Running", false);
		Anim.speed = 2.2f;
		_boxCollider.size = _defaultSizeOfCollider;
		_boxCollider.offset = _defaultoffsetOfCollider;

	}
}


