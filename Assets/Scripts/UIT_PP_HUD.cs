using UnityEngine;
using System.Collections;

public class UIT_PP_HUD : MonoBehaviour {

	UIText fnt;

	UITextInstance[] PlayerScores;
	UISprite[] PlayerIcons;

	UITextInstance TimeRemaining;
	UITextInstance TimeLabel;

	public Transform[] PlayerHUDPositions;

	const string TIMER_LABEL = "Timer";

	public float xScale = 1;
	public float yScale = 1;

	public Vector2 textOffset = new Vector2(64, 32);
	public float scoreTextScale = 0.8f;

	// Use this for initialization
	void Start () {
		PlayerScores = new UITextInstance[4];
		PlayerIcons = new UISprite[4];

		UIText fnt = new UIText("Pourquoi64", "Pourquoi64.png");

		yScale = Mathf.Clamp ((float)Screen.width / 1080, 0, 1);

		for (int i=0; i < 4; i++)
		{
			PlayerScores[i] = fnt.addTextInstance("00%", 0, 0);

			PlayerHUDPositions[i].GetComponent<HUDDogeMasterControllerUIT>().percentageDisplay = PlayerScores[i];

			PlayerScores[i].setColorForAllLetters(Color.yellow);
			PlayerScores[i].textScale = scoreTextScale * yScale;
			PlayerScores[i].text = i.ToString() + "00%";
			Debug.Log (i);

			//string dogeFileName = "dogePortrait0" + (i + 1).ToString();
			//PlayerIcons[i] = new UISprite(

		}
	}
	
	// Update is called once per frame
	void Update () {
		AlignScoreHUD();
	}

	void AlignScoreHUD() {
		for (int i=0; i < 4; i++)
		{
			Vector3 playerWorldPos = PlayerHUDPositions[i].position;
			playerWorldPos.z = 0;
			Vector3 screenPos = Camera.main.WorldToScreenPoint(playerWorldPos);
			screenPos.y = Screen.height - screenPos.y;
			
			if (i % 2 == 0) //left side of the screen
			{
				//PlayerScores[i].alignMode = UITextAlignMode.Left;
				PlayerScores[i].xPos = screenPos.x + textOffset.x * yScale;
			}
			else //right side of the screen
			{
				PlayerScores[i].alignMode = UITextAlignMode.Right;
				PlayerScores[i].xPos = screenPos.x - textOffset.x * yScale;
			}
			
			if (i < 2) // top of screen
			{
				PlayerScores[i].yPos = screenPos.y - 32*yScale*scoreTextScale - 32*yScale;
			}
			else //bottom of screen
			{
				PlayerScores[i].yPos = screenPos.y - 32*yScale*scoreTextScale + 32*yScale;
			}
		}

	}
}
