﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PickUp: MonoBehaviour
{
    public Transform dest;
    public Rigidbody rb;
    States states;

    bool pickedup = false;
    bool hover = false;

    GameObject PlayerObject;

    float minDistanceToObject = 5;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        states = GameObject.Find("StateObject").GetComponent<States>();
        PlayerObject = GameObject.Find("Player");
    }

    private void Update()
    {
        PickUpItem();
    }

    void OnMouseOver()
    {
        hover = true;
        // Debug.Log("hovered:" + hover);
        
    }

    private void OnMouseExit()
    {
        hover = false;
        //Debug.Log("hovered:" + hover);
    }

    void PickUpItem()
    {
        float distance = Vector3.Distance(this.transform.position, PlayerObject.transform.position);

        if (Input.GetKeyDown(KeyCode.E) && distance < minDistanceToObject)
        {
            if (!pickedup && hover)
            {
                rb.useGravity = false; //turn off gravity
                //rb.freezeRotation = true;
                this.transform.position = dest.position;
                this.transform.parent = GameObject.Find("Destination").transform;


                pickedup = true;
                //Debug.Log("pickedup=" + pickedup);
            }
        else
        {
            this.transform.parent = null;
            rb.useGravity = true;

            //rb.freezeRotation = false;
            pickedup = false;

            //Debug.Log("pickedup=" + pickedup);
        }
            if (!pickedup)
            {
                rb.useGravity = true;
            }
        }

    }

        

}
