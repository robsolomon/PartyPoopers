using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoopMaster : MonoBehaviour {
	
	//List<CollectablePoop> Collectables;

	public GameObject PoopPrefab;
	public GameObject[] Poops;
	public GameObject[] Collectables;

	public bool useMultiPoops = false;

	public Rect spawnBounds = new Rect(-30, -20, 60, 40);

	Rect spawnRect;

	// Use this for initialization
	void Awake () {
		spawnRect = spawnBounds;

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.P))
		{
			SpawnMorePoops(20);
		}
		if (Input.GetKeyDown(KeyCode.O))
		{
			SpawnMoreFood(20);
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			SpawnMoreFood();
		}
		if (Input.GetKeyDown(KeyCode.Return))
		{
			SpawnMorePoops();
		}
	
	}

	public void SpawnPileOfStuff()
	{
		SpawnMorePoops(20);
		SpawnMoreFood(20);
	}

	void SpawnMoreFood()
	{
		SpawnMoreFood(1);
	}

	void SpawnMoreFood(int num)
	{
		if (Collectables.Length == 0)
			return;
		for (int i=0; i < num; i++)
		{
			int itemIndex = Random.Range (0, Collectables.Length);
			GameObject spawn = (GameObject)GameObject.Instantiate(Collectables[itemIndex]);
			spawn.transform.position = generatePositionWithinBounds();
			spawn.transform.parent = transform;
		}

	}

	void SpawnMorePoops()
	{
		SpawnMorePoops(1);
	}

	void SpawnMorePoops(int numberOfPoops)
	{
		for (int i=0; i < numberOfPoops; i++)
		{
			GameObject poop;
			if (useMultiPoops)
			{
				//use the multi-poops
				int itemIndex = Random.Range (0, Poops.Length);
				poop = (GameObject)GameObject.Instantiate(Poops[itemIndex]);
			}
			else
			{
				poop = (GameObject)GameObject.Instantiate(PoopPrefab);
			}

			poop.transform.position = generatePositionWithinBounds();
			poop.transform.parent = transform;
		}

	}

	Vector3 generatePositionWithinBounds()
	{
		Vector3 output = new Vector3();
		output.x = Random.Range (spawnRect.x, spawnRect.x + spawnRect.width);
		output.y = Random.Range (spawnRect.y, spawnRect.y + spawnRect.height);
		return output;
	}


}
