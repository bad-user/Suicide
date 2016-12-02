using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour
{

	public static GameController instance;
	private static bool _sound;
	private static int currnetLevel = 0;
	private AudioSource _audioSource;

	private int _menuScene = 0;

	public const string START_FOR_THE_FIRST_TIME = "START_FOR_THE_FIRST_TIMEffff";
	public const string LEVLES_OPEND = "LEVLES_OPEND";

	// Use this for initialization
	void Awake ()
	{
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
			_sound = true;
			_audioSource = GetComponent<AudioSource> ();
		}
	}

	public void InitMenuLevels ()
	{
		MenuButtonController mbc;
		if (!PlayerPrefs.HasKey (START_FOR_THE_FIRST_TIME)) {
			PlayerPrefs.SetInt (START_FOR_THE_FIRST_TIME, 1);
			PlayerPrefs.SetInt (LEVLES_OPEND, 1);
		}
		int levels = PlayerPrefs.GetInt (LEVLES_OPEND);
		for (int i = 1; i <= 12; i++) {
			mbc = GameObject.Find ("Level" + i).GetComponent<MenuButtonController> ();
			if (i <= levels) {
				mbc.getTextComponent ().text = i + "";
				mbc.SetActive (true);
			} else {
				mbc.getTextComponent ().text = "";
				mbc.SetActive (false);
			}
		}

	}

	public void UpdateLevelsOpened (int l)
	{
		if (l > PlayerPrefs.GetInt (LEVLES_OPEND)) {
			PlayerPrefs.SetInt (LEVLES_OPEND, l);
		}
	}


	public void NextLevel ()
	{
		StartCoroutine (NextLeveCou ());
	}

	private IEnumerator NextLeveCou ()
	{
		yield return new WaitForSeconds (0.5f);
		SceneManager.LoadScene (currnetLevel + 1);
		currnetLevel++; 

		UpdateLevelsOpened (currnetLevel);
	}

	public void RestartLevel ()
	{
		SceneManager.LoadScene (currnetLevel);
	}

	public void GoToMenu ()
	{
		SceneManager.LoadScene (_menuScene);
		currnetLevel = _menuScene;
	}

	public void loadLevelFromButtons (int level)
	{
		currnetLevel = level;
		LoadLevel (level);
	}

	private void LoadLevel (int level)
	{
		SceneManager.LoadScene (level);
	}

	public int GetCurrentLevel ()
	{

		return currnetLevel;
	}

	public void ToggleSound ()
	{
		if (_sound)
			_audioSource.Stop ();
		else
			_audioSource.Play ();

		_sound = !_sound;
	}

	public bool IsSoundActive ()
	{
		return _sound;
	}

}
