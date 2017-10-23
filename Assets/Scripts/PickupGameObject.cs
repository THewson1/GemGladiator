using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGameObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            OnPickup();
        }
    }

    public virtual void OnPickup() { }
}
