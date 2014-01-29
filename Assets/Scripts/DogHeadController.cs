using UnityEngine;
using InControl;
using System.Collections;

public class DogHeadController : MonoBehaviour {

	DogController body;
	InputDevice iDevice;
	Vector3 headOriginPos;


	// Use this for initialization
	void Start () {
		DogController body = transform.parent.GetComponent<DogController>();
		iDevice = body.iDevice;


		
	}
	
	// Update is called once per frame
	void Update () {




	
	}



}
