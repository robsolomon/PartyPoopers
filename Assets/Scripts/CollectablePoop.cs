using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
[RequireComponent (typeof (Rigidbody2D))]
//[RequireComponent (typeof (PolygonCollider2D))] //remove this later post-jam
public class CollectablePoop : MonoBehaviour {

	public AudioClip collectionSound;
	public AudioClip collisionSound;

	public int PointValue = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {

		Debug.Log ("poopcollides: " + other.name);
		DogController control = other.gameObject.GetComponent<DogController>();
		if (control != null)
		{
			control.takePoop(gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		DogController control = other.gameObject.GetComponent<DogController>();
		if (control != null)
		{
			control.leavePoop(gameObject);
		}

	}

	void OnCollisionEnter2D(Collision2D coll) {

		DogController control = coll.gameObject.GetComponent<DogController>();
		if (control != null)
		{
			control.takePoop(gameObject);
		}

		AudioCollisionPlay(coll.relativeVelocity.sqrMagnitude/530);
	}

	void OnCollisionExit2D(Collision2D coll) {
		DogController control = coll.gameObject.GetComponent<DogController>();
		if (control != null)
		{
			control.leavePoop(gameObject);
		}

	}

	public void CleanUpAndDestroy()
	{
		//Destroy(gameObject.GetComponent<Rigidbody2D>());
		//Destroy(gameObject.GetComponent<Collider2D>());
		if (collectionSound != null)
			AudioSource.PlayClipAtPoint(collectionSound, transform.position);
		Destroy(gameObject);

	}

	public void AudioCollisionPlay(float volume)
	{
		if (!audio.isPlaying && collisionSound != null)
		{
			//Debug.Log ("Vel:" + coll.relativeVelocity.sqrMagnitude); //530
			audio.clip = collisionSound;
			audio.volume = volume;
			audio.Play();
		}
	}

	public void AudioCollectionPlay(float volume)
	{


	}
}
