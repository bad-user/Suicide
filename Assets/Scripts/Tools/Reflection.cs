using UnityEngine;
using System.Collections;

public class Reflection : MonoBehaviour {

	public enum Directions{
		UP,
		DWON,
		RIGHT,
		LEFT,
		Reflect
	}

	public Directions DirectionRightLeft;
	public Directions DirectionUpDown;
}
