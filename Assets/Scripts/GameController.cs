using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject m_playerPrefab;
    [Range(1, 4)] public int m_amountOfPlayers;

    [HideInInspector] public int m_amountOfGems;
    [HideInInspector] public List<GameObject> m_listOfPlayers = new List<GameObject>();

	// Use this for initialization
	void Start () {
        //create the correct amount of players at the start of the game

		for (int i = -m_amountOfPlayers/2; i <= m_amountOfPlayers/2; i++)
        {
            if (i == 0)
            {
                if (m_amountOfPlayers % 2 != 0)
                {
                    CreatePlayer(0);
                }
            }
            else
            {
                CreatePlayer(i);
            }
        }
        AddPlayersToBoulderTargets();
    }

    private void CreatePlayer(int i)
    {
        GameObject newPlayer = Instantiate(m_playerPrefab, new Vector3(i, 5, 0), Quaternion.identity);
        m_listOfPlayers.Add(newPlayer);
    }

    private void AddPlayersToBoulderTargets()
    {
        BounceInternaly boulderBouncingScript = GameObject.FindGameObjectWithTag("Boulder").GetComponent<BounceInternaly>();
        foreach (GameObject player in m_listOfPlayers)
            boulderBouncingScript.m_objectsToBounceTowards.Add(player);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
