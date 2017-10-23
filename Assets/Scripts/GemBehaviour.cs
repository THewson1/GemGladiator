using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PickupGameObject))]
public class GemBehaviour : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnPickup()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().m_amountOfGems++;
    }
}

    
