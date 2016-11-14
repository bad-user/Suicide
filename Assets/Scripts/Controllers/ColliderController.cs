using UnityEngine;
using System.Collections;

public class ColliderController : MonoBehaviour {


	void Awake(){
		BoxCollider2D boxColl = GetComponent<BoxCollider2D> ();
		boxColl.offset = new Vector2 (0,0);
		boxColl.size = GetComponent<RectTransform> ().rect.size;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
