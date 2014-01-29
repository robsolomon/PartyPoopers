using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	//UIToolkit is a nightmare, never rely on it in a short time period... my god

	public PoopMaster spawner;

	static GameManager mInstance;
	public static GameManager Instance
		
	{
		get
		{
			if (mInstance == null)
				mInstance = (new GameObject("!GM")).AddComponent<GameManager>();
			return mInstance;
		}
	}

	public List<float> m_playerScores;

	public HUDDogeMasterController[] HUD;
	public HUDDogeMasterControllerUIT[] HUDuit;

	public bool useNewHUD = false;

	int m_indexOfLeader = 0;

	public void ScorePlayer(float points, int playerID)
	{
		int i = playerID - 1;
		if (i >= m_playerScores.Count)
			return;
		m_playerScores[i] += points;
		if (useNewHUD)
		{
			if (i >= HUDuit.Length)
				return;
			HUDuit[i].currentScore = m_playerScores[i];

		}
		else
		{
			if (i >= HUD.Length)
				return;
			HUD[i].currentScore = m_playerScores[i];
		}

		AssignLeader();

	}

	void AssignLeader()
	{
		float highScore = 0;
		for (int i=0; i< m_playerScores.Count; i++)
		{
			if (useNewHUD)
			{
				if (i < HUDuit.Length)
					HUDuit[i].isLeader = false;
			}
			else
			{
				if (i < HUD.Length)
					HUD[i].isLeader = false;
			}

			if (m_playerScores[i] > highScore)
			{
				highScore = m_playerScores[i];
				m_indexOfLeader = i;
			}
			else if (m_playerScores[i] == highScore)
			{
				m_indexOfLeader = -1;
			}
		}
		if (m_indexOfLeader != -1)
		{
			if (useNewHUD)
			{
				if (m_indexOfLeader < HUDuit.Length)
					HUDuit[m_indexOfLeader].isLeader = true;
			}
			else
			{
				if (m_indexOfLeader < HUD.Length)
					HUD[m_indexOfLeader].isLeader = true;
			}
		}

	}

	void Awake() {
		//if (useNewHUD)
		//	GameObject.Instantiate(UIToolkitPrefab);
		mInstance = this;
		GameObject inputManager = new GameObject("InputManager");
		inputManager.AddComponent<UpdateInputManager>();
		inputManager.transform.parent = transform;
	}

	// Use this for initialization
	void Start () {
		m_playerScores = new List<float>(4);
		for (int i=0; i < 4; i++)
		{
			m_playerScores.Add (0);
		}

		if (spawner != null)
		{
			spawner.SpawnPileOfStuff();
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	
	}

}
