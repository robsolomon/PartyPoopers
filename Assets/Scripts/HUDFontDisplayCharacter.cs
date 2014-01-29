using UnityEngine;
using System.Collections;

public class HUDFontDisplayCharacter : MonoBehaviour {

	public int currentDigit
	{
		get { return _currentDigit; }
		set
		{
			int index = Mathf.Clamp(value, 0, 11);
			if (index != _currentDigit)
			{
				Characters[_currentDigit].SetActive(false);
				Characters[index].SetActive (true);
				_currentDigit = index;
			}
		}
	}

	private int _currentDigit = 0;

	public GameObject[] Characters;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
