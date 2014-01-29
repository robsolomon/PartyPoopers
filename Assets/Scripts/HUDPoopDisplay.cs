using UnityEngine;
using System.Collections;

public class HUDPoopDisplay : MonoBehaviour {

	public GameObject[] Poops;

	const int MAX_POOPS = 7;

	public int CurrentPoops
	{
		get { return _currentPoops; }
		set
		{
			if (value != _currentPoops)
			{
				_currentPoops = Mathf.Clamp(value, 0, MAX_POOPS);
				//manipulate HUD here
				RefreshDisplay();
			}
		}
	}

	private int _currentPoops = 0;

	// Use this for initialization
	void Start () {
		RefreshDisplay();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void RefreshDisplay() {
		for (int i=0; i < Poops.Length; i++)
		{
			if (i < _currentPoops)
			{
				Poops[i].active = true;
			}
			else
			{
				Poops[i].active = false;
			}
		}
	}
}
