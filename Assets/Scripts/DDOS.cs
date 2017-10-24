using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDOS : MonoBehaviour {
    private static DDOS instance = null;
    public static DDOS Instance
    {
        get { return instance; }
    }

	// Use this for initialization
	void Awake () {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
	}

    public int gameModeSelected;
    
	// Update is called once per frame
	void Update () {
		
	}
}
