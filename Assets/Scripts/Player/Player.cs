using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	public static Player insatance;

	private bool _isFacingRight;
	private CharacterController2D _controller;
	private float _normalizedHorizontalSpeed;
	private SpriteRenderer _spriteRenderer;
	private BoxCollider2D _boxCollider;
	private Vector2 _defaultSizeOfCollider;
	private Vector2 _defaultoffsetOfCollider;
	private float _deltaColliderSize = 0.07f;
	private bool _movingRight, _movingLeft, _movingUp;

	public float MaxSpeed = 8f;
	public float SpeedAccelerationOnGround = 10f;
	public float SpeedAccelerationInAir = 5f;
	public Animator Anim;
	public bool IsAlive { get; set;}

	public void Awake ()
	{
		if (insatance == null) {
			insatance = this;
			_boxCollider = GetComponent<BoxCollider2D> ();
			_spriteRenderer = GetComponent<SpriteRenderer> ();
			_controller = GetComponent<CharacterController2D> ();

			_defaultSizeOfCollider = _boxCollider.size;
			_defaultoffsetOfCollider = _boxCollider.offset;
			_movingLeft = _movingRight = false;

			IsAlive = true;
		}
	}

	public void Start ()
	{
		_isFacingRight = !_spriteRenderer.flipX;
	}

	public void Update ()
	{
		if (IsAlive) {
			HandleInput ();

			var movementFactor = _controller.State.IsGrounded ? SpeedAccelerationOnGround : SpeedAccelerationInAir;
			_controller.SetHorizontalForce (Mathf.Lerp (_controller.Velocity.x, _normalizedHorizontalSpeed * MaxSpeed, movementFactor * Time.deltaTime));
		} else {
			_controller.SetForce (Vector2.zero);
		}
	}

	private void HandleInput ()
	{
		if (Input.GetKey (KeyCode.RightArrow) || _movingRight) {
			_normalizedHorizontalSpeed = 1;
			RunningAnimation ();
			if (!_isFacingRight) {
				Flip ();
			}
		} else if (Input.GetKey (KeyCode.LeftArrow) || _movingLeft) {
			_normalizedHorizontalSpeed = -1;
			RunningAnimation ();
			if (_isFacingRight) {
				Flip ();
			}
		} else {
			_normalizedHorizontalSpeed = 0;
			IdleAnimation ();
		}

		if ((_movingUp || Input.GetKey (KeyCode.UpArrow)) && _controller.CanJump) {
			_controller.Jump ();
			_movingUp = false;
		}
	}

	private void Flip ()
	{
		_isFacingRight = _spriteRenderer.flipX;
		_spriteRenderer.flipX = !_spriteRenderer.flipX;
	}

	private void RunningAnimation ()
	{
		if (IsAlive) {

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

	}

	private void IdleAnimation ()
	{
		Anim.speed = 100f;
		Anim.SetBool ("Running", false);
		_boxCollider.size = _defaultSizeOfCollider;
		_boxCollider.offset = _defaultoffsetOfCollider;

	}

	private void DieAnimation(){
		Anim.speed = 1f;
		Anim.SetBool ("Die", true);

	}

	public void die(){
		IsAlive = false;
		IdleAnimation ();
		DieAnimation ();
		Destroy (gameObject);
		StartCoroutine (NextLeveCou());
	}

	private void nextLevel(){
		GameController.instance.NextLevel ();
	}

	public void MoveRight(){
		_movingRight = true;
	}

	public void StopMovingRight(){
		_movingRight = false;
	}

	public void MoveLeft(){
		_movingLeft = true;
	}

	public void StopMovingLeft(){
		_movingLeft = false;
	}

	public void Jump(){
		if (_controller.CanJump) {
			_movingUp = true;
		}
	}


	private IEnumerator NextLeveCou(){
		yield return new WaitForSeconds (0.5f);
		nextLevel();
	}

}


