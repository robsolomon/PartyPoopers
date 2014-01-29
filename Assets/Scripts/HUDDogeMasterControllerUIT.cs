﻿using UnityEngine;
using System.Collections;

public class HUDDogeMasterControllerUIT : MonoBehaviour {

	public int playerIndex = 0;
	
	public HUDPoopDisplay poopHUD;
	
	public float currentScore = 0;
	
	public bool isLeader = false;

	public UITextInstance percentageDisplay;
	
	public GameObject PartyHat;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		UpdatePercentageDisplay();
		PoopDisplayTest ();
		UpdateLeaderStatus();
	}
	
	void UpdateLeaderStatus()
	{
		if (PartyHat != null)
			PartyHat.SetActive(isLeader);
		if (isLeader)
		{
			//TODO: grow and shrink hat to draw attention to it here w/ LeanTween
			
		}
	}
	
	void UpdatePercentageDisplay()
	{
		if (percentageDisplay == null)
			return;
		string percentageDisplayText = "";
		if (currentScore < 100)
		{
			percentageDisplayText += " ";
		}
		percentageDisplayText += Mathf.RoundToInt(currentScore).ToString () + "%";
		percentageDisplay.text = percentageDisplayText;
	}
	
	void PoopDisplayTest()
	{
		int poopsToShow = Mathf.RoundToInt(currentScore) / 100;
		poopHUD.CurrentPoops = poopsToShow;
		
	}


	public void PopIcon()
	{
		//TODO, put some nice LeanTween effects in here
		//LeanTween.scale (gameObject, new Vector3(1.2f, 1.2f, 0), 0.2f);

	}
}