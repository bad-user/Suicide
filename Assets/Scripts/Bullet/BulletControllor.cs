using UnityEngine;
using System.Collections;

public class BulletControllor : MonoBehaviour
{

	public GameObject explosion;
	public static float speed = 10f;
	private int _direction;

	private bool _moveRight;
	private bool _moveLeft;
	private Rigidbody2D _rigidBody;

	// Use this for initialization
	void Awake ()
	{
		_rigidBody = GetComponent<Rigidbody2D> ();
		_rigidBody.velocity = new Vector2 (1, 0) * speed * _direction;
	}

	public void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "Boundry") {
			Destroy (gameObject);
			return;
		}
		if (coll.gameObject.tag == "Reflect") {
			Reflection rf = coll.gameObject.GetComponent<Reflection> ();
			bool reflect = (rf.DirectionRightLeft == Reflection.Directions.Reflect)
			               || (rf.DirectionUpDown == Reflection.Directions.Reflect);
			
//			bool goStarait = (rf.DirectionRightLeft == Reflection.Directions.RIGHT)
//				||(rf.DirectionRightLeft == Reflection.Directions.LEFT);
			if (!reflect && transform.localRotation.eulerAngles.z == 0) {
				if ( rf.DirectionUpDown == Reflection.Directions.UP) {
					_rigidBody.velocity = new Vector2 (0, 1) * speed;
					transform.localRotation = Quaternion.Euler (0, 0, 90);
				} else if (rf.DirectionUpDown == Reflection.Directions.DWON) {
					_rigidBody.velocity = new Vector2 (0, -1) * speed;
					transform.localRotation = Quaternion.Euler (0, 0, 90);
				}
			} else {
				if (rf.DirectionRightLeft == Reflection.Directions.RIGHT) {
					_rigidBody.velocity = new Vector2 (1, 0) * speed ;
					transform.localRotation = Quaternion.Euler (0, 0, 0);
				} else if (rf.DirectionRightLeft == Reflection.Directions.LEFT) {
					_rigidBody.velocity = new Vector2 (-1, 0) * speed ;
					transform.localRotation = Quaternion.Euler (0, 0, 0);
					Debug.Log (_rigidBody.velocity + "/////");
				}

			}
		} else {
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (gameObject);

			if (coll.gameObject.tag == "Player") {
				Player.insatance.die ();
			}
		}
			
	}

	public void SetDirection (int d)
	{
		if (!(d == 1 || d == -1)) {
			return;
		}
		_direction = d;
		_rigidBody.velocity = new Vector2 (1, 0) * speed * _direction;
	}


}
