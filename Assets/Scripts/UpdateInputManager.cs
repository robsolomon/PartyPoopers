using UnityEngine;
using InControl;

public class UpdateInputManager : MonoBehaviour
{

	InputDevice Player1;

	void Awake()
	{
		//Input.GetJoystickNames();
		InputManager.Setup();
	
	}

	void Start()
	{
		for (int i=0; i < InputManager.Devices.Count; i++)
		{
			switch (i)
			{
			case 0:
				Player1 = InputManager.Devices[0];
				break;
			}
		}
	}
	
	void Update()
	{
		InputManager.Update();
	}
}