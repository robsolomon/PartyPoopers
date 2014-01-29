using UnityEngine;
using System.Collections;

public class UIT_TextDisplayTest : MonoBehaviour {

	UITextInstance text;
	UITextInstance text2;

	// Use this for initialization
	void Start () {
		UIText fnt = new UIText("Pourquoi64", "Pourquoi64.png");
		text = fnt.addTextInstance("The quick brown fox", 20, 20);
		text.setColorForAllLetters(Color.yellow);
		text2 = fnt.addTextInstance("jumps over the lazy dog", 20, 60, 0.75f);
		text2.setColorForAllLetters(Color.red);
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "WOO HOO";
	
	}
}
