using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuButtonController : MonoBehaviour {



	private UnityEngine.UI.Button _button;
	private Text _textChild;
	private Image _image;


	// Use this for initialization
	void Awake () {
		_button = GetComponent<UnityEngine.UI.Button> ();
		_textChild = transform.GetChild (0).gameObject.GetComponent<Text>();
		_button.onClick.RemoveAllListeners ();
		_image = GetComponent<Image> ();
	}


	public void LoadLevelOnButtonClicked(){
		if (_textChild.text == "")
			return;
		
		int level = int.Parse (_textChild.text);
		_button.onClick.AddListener (() => GameController.instance.loadLevelFromButtons(level));
	}

	public Text getTextComponent(){
		return _textChild;
	}

	public void SetActive(bool status){
		if (status) {
			_image.sprite = MenuController.instance.ActivedSprite;
		} else {
			_image.sprite =  MenuController.instance.DeactivedSprite;
		}

		LoadLevelOnButtonClicked ();
	}
	

}
