using UnityEngine;
using InControl;
using System.Collections;

public class DogControl : MonoBehaviour {
	
	public int playerID = 1;
	InputDevice iDevice;
	public GameObject buttonTest;
	public GameObject head;
	Vector3 eulerRotation = new Vector3();
	Vector3 headOriginPos;
	
	float angle = 0;
	
	// Use this for initialization
	void Start () {
		if (InputManager.Devices.Count >= playerID)
		{
			iDevice = InputManager.Devices[playerID - 1];
		}
		headOriginPos = head.transform.localPosition;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (iDevice.Action1.IsPressed)
		{
			buttonTest.transform.localScale = new Vector3(2, 2, 2);
		}
		else
		{
			buttonTest.transform.localScale = new Vector3(1, 1, 1);
		}
		eulerRotation.z -= iDevice.LeftStickX;
		transform.eulerAngles = eulerRotation;
		
		Vector3 position = transform.localPosition;
		angle -= iDevice.LeftStickX;

		Vector2 positionChange = new Vector2();
		positionChange.x = Mathf.Cos(angle * Mathf.PI / 180) * -iDevice.LeftStickY * 10;
		positionChange.y = Mathf.Sin(angle * Mathf.PI / 180) * -iDevice.LeftStickY * 10;
		transform.rigidbody2D.AddForce(positionChange);
		/*
		position.x -= positionChange.x;
		position.y -= positionChange.y;
		transform.localPosition = position;
		*/
		head.transform.localPosition = new Vector3(headOriginPos.x - iDevice.RightTrigger * 0.02f, headOriginPos.y, headOriginPos.z);
		
		/*
this.x +=   this.speed * Math.cos(angle * Math.PI / 180);
this.y +=   this.speed * Math.sin(angle * Math.PI / 180);
		 */
		//Vector3 positionUpdate = new Vector3(iDevice.LeftStickVector.x, iDevice.LeftStickVector.y, 0);
		//transform.localPosition += positionUpdate;
	}
}
