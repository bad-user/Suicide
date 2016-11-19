using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController instance;
	private static int currnetLevel = 0;
	// Use this for initialization
	void Start () {
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void NextLevel(){
		SceneManager.LoadScene (currnetLevel + 1);
		currnetLevel++; 
	}


}
