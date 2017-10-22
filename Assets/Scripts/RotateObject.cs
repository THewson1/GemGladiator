using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour {

	public float XRot;
	public float YRot;
	public float ZRot;
		
	// Update is called once per frame
	void Update () 
	{
		//rotates object
		transform.Rotate (XRot * Time.deltaTime, YRot * Time.deltaTime, ZRot * Time.deltaTime, Space.Self);		
	}
}
