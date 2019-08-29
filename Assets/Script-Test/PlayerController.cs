﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{

	public LayerMask movementMask;
	Camera cam;
	PlayerMotor motor;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
        	Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        	RaycastHit hit;

        	if(Physics.Raycast(ray, out hit, 100, movementMask)){

        		//Move our player to what we hit
        		motor.moveToPoint(hit.point);
        		
        	}
        }
    }
}
