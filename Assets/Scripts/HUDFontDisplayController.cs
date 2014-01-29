using UnityEngine;
using System.Collections;

public class HUDFontDisplayController : MonoBehaviour {

	public bool usePercentage = false;

	public int number = 0;
	private int lastNumber = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (number != lastNumber)
		{
			int numOfDigits = number.ToString().Length;
			for (int i=0; i< numOfDigits; i++)
			{


			}
			lastNumber = number;
		}
		
	}
}
