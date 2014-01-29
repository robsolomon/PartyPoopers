using UnityEngine;
using InControl;
using System.Collections;

public class DogController : MonoBehaviour {

	public int playerID = 1;
	public InputDevice iDevice;
	Vector3 eulerRotation = new Vector3();
	public GameObject debugDirection;

	public bool readyToEat = true;

	GameObject headObject;
	Vector3 headOriginPos;

	public Vector2 leftStickVector;
	
	float debugAngle = 0;

	public float maximumDrag = 5;

	public float positionForceMultiplier = 10;

	bool onPoop = false;
	GameObject currentCollectable;	
	//public AudioClip poopCollectSound;

	public AudioClip[] munchSounds;
	private int lastMunchIndex = -1;

	public AudioClip barkSound;
	private bool barkReady = true;

	Animator animator;

	// Use this for initialization
	void Start () {
		if (InputManager.Devices.Count >= playerID)
		{
			iDevice = InputManager.Devices[playerID - 1];
		}
		else
		{
			Destroy (gameObject);
		}

		headObject = transform.FindChild("dogScratchHead").gameObject;
		headOriginPos = headObject.transform.localPosition;

		animator = gameObject.GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {

		if (iDevice.LeftStickVector.magnitude > 0.1f)
		{
			transform.rigidbody2D.fixedAngle = true;
		}
		else
		{
			transform.rigidbody2D.fixedAngle = false;
		}

		/*
		Vector3 targetDir = target.position - transform.position;
		float step = speed * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
		Debug.DrawRay(transform.position, newDir, Color.red);
		transform.rotation = Quaternion.LookRotation(newDir);
		*/

		transform.rigidbody2D.drag = maximumDrag; //- maximumDrag*iDevice.LeftTrigger;

		leftStickVector = iDevice.Direction;

		if (debugDirection != null)
		{
			debugDirection.transform.localPosition = new Vector3(0, 0, 0);
			debugDirection.transform.position += new Vector3(leftStickVector.x * 10, leftStickVector.y * 10);
			/*
			Vector2.MoveTowards(Vector2.zero, iDevice.LeftStickVector, 5);

			Vector2.MoveTowards(Vector2 current, Vector2 target, float maxDistanceDelta)
			Vector3 newDir = Vector3.RotateTowards (transform.forward, debugDirection.transform.position, 10, 0.0f);
			Debug.DrawRay(transform.position, newDir, Color.red);
			transform.rotation = Quaternion.LookRotation(newDir);
			*/
		}

		if (animator != null)
		{
			animator.speed = leftStickVector.magnitude * 3;
			if (animator.speed == 0)
			{
				//animator.GetComponentsInChildren

				//This is what I would have LIKED to do
				//animator.animation.Rewind();
			}
		}

		if (leftStickVector.magnitude > 0.1f)
		{

			//old rotation style
			float targetRotation = -(float)Mathf.Atan2(-leftStickVector.y, leftStickVector.x) * Mathf.Rad2Deg + 180;
			//transform.eulerAngles = eulerRotation;
			eulerRotation = transform.eulerAngles;

			var r = transform.eulerAngles;

			/*
			float a = eulerRotation.z - targetRotation;
			a = (a + 180) % 360 - 180;
			float rotationSpeed = 1;

			float speedFactor = a * rotationSpeed / Time.time;

			Debug.Log (eulerRotation.z + " " +  targetRotation + " " + speedFactor);	
			*/
			transform.rotation = Quaternion.Euler(r.x, r.y, Mathf.LerpAngle(eulerRotation.z, targetRotation, Time.time));

			//eulerRotation.z = targetRotation;
			debugAngle = eulerRotation.z;
		}

		if (iDevice.LeftTrigger > 0.5f)
		{
			if (barkReady && barkSound != null)
			{
				if (audio.isPlaying)
					audio.Stop();
				barkReady = false;
				audio.clip = barkSound;
				audio.pitch = Random.Range (0.95f, 1.05f);
				audio.volume = Mathf.Clamp (iDevice.LeftTrigger * 2, 0, 1);
				audio.Play();
			}
		}
		else
		{
			barkReady = true;
		}

		Vector2 positionChange = leftStickVector * positionForceMultiplier;

		transform.rigidbody2D.AddForce(positionChange * positionChange.magnitude);

		headAction();

		/*
this.x +=   this.speed * Math.cos(angle * Math.PI / 180);
this.y +=   this.speed * Math.sin(angle * Math.PI / 180);
		 */
		//Vector3 positionUpdate = new Vector3(iDevice.LeftStickVector.x, iDevice.LeftStickVector.y, 0);
		//transform.localPosition += positionUpdate;
	}

	public void headAction()
	{
		headObject.transform.localPosition = new Vector3(headOriginPos.x - iDevice.RightTrigger * 0.02f, headOriginPos.y, headOriginPos.z);
		headObject.transform.localScale = new Vector3(1 + iDevice.RightTrigger * 0.2f, 1 + iDevice.RightTrigger * 0.2f, 1);

		//check for poop to eat	
		if (readyToEat && iDevice.RightTrigger > 0.9f)
		{
			if (onPoop)
			{
				readyToEat = false;
				eatPoop ();
			}
		}
		if (iDevice.RightTrigger < 0.2f)
		{
			readyToEat = true;
		}
	}

	public void takePoop(GameObject collectable)
	{
		currentCollectable = collectable;
		onPoop = true;
	}

	public void leavePoop(GameObject collectable)
	{
		if (collectable.Equals (currentCollectable))
		{
			onPoop = false;
			currentCollectable = null;
		}
	}

	public void eatPoop()
	{
		playMunchingSound();
		CollectablePoop poop = currentCollectable.GetComponent<CollectablePoop>();
		GameManager.Instance.ScorePlayer(poop.PointValue, playerID);
		poop.CleanUpAndDestroy();
		onPoop = false;
	}

	public void playMunchingSound()
	{
		if (audio.isPlaying)
			return;
		if (munchSounds != null || munchSounds.Length > 0)
		{
			int randomMunchIndex = 0;
			if (munchSounds.Length > 1)
			{
				randomMunchIndex = Random.Range(0, munchSounds.Length);
				if (randomMunchIndex == lastMunchIndex)
				{
					randomMunchIndex++;
					if (randomMunchIndex >= munchSounds.Length)
					{
						randomMunchIndex = 0;
					}
				}
			}
			else
			{
				randomMunchIndex = 0;
			}
			audio.clip = munchSounds[randomMunchIndex];
			audio.Play();
		}
	}
}
