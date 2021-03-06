﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

[RequireComponent(typeof(PlayerController))]
public class PlayerInput : MonoBehaviour {

    [Tooltip("time until the player can dodge again in seconds")]
    [SerializeField] private float m_dodgeCooldown = 2f;
    private PlayerController m_Character; // A reference to the PlayerController on the object
    private InputDevice usersController = new InputDevice("none");
    [SerializeField] private int m_playerNumber = -1;

    private Vector3 m_move;
    private int m_dodging;

    //public accessor for the player number
    public int PlayerNumber
    {
        get { return m_playerNumber; }
        set { m_playerNumber = value;
            if (InputManager.Devices.Count > 0)
                usersController = InputManager.Devices[m_playerNumber];
        }
    }

    // Use this for initialization
    void Start () {
        m_Character = GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
	}

    private void FixedUpdate()
    {
        float h;
        float v;

        h = usersController.LeftStickX;
        v = usersController.LeftStickY;

        if (m_dodging == 0 && usersController.Action2.WasPressed)
        {
            m_dodging = 1;
            Invoke("CoolDownDodge", m_dodgeCooldown);
        }

#if UNITY_EDITOR
            
        if (InputManager.Devices.Count == 0)
        {
            h = ((Input.GetKey(KeyCode.A)? -1:0) - (Input.GetKey(KeyCode.D) ? -1 : 0));
            v = ((Input.GetKey(KeyCode.W) ? 1 : 0) - (Input.GetKey(KeyCode.S) ? 1 : 0));

            if (m_dodging == 0 && Input.GetKeyDown(KeyCode.LeftShift))
            {
                m_dodging = 1;
                Invoke("CoolDownDodge", m_dodgeCooldown);
            }
        }
            
#endif

        // we use world-relative directions in the case of no main camera
        m_move = new Vector3(-h, 0, -v);

        m_Character.Move(m_move, ref m_dodging);
        
    }

    void CoolDownDodge()
    {
        m_dodging = 0;
    }

}
