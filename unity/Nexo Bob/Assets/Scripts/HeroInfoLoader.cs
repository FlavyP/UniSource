using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeroInfoLoader : MonoBehaviour {

	public Text NameHolder;
	public Image AvatarHolder;

	public Sprite[] AllAvatars = new Sprite[2];

	// Use this for initialization
	void Start () {
		NameHolder.text = PlayerPrefs.GetString ("Hero", "Clay");
		AvatarHolder.sprite = AllAvatars[0];
	}
}
