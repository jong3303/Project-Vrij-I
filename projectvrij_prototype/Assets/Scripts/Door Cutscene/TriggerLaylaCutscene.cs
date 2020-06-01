﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLaylaCutscene : MonoBehaviour
{
    Dialogue2 dialogue2;
    bool laylaCutscene = false;
    States states;
    GameObject triggerc;

    ContinueLaylaCutscene laylascene;
    // Start is called before the first frame update
    void Start()
    {
        dialogue2 = GameObject.Find("TriggerCutscene").GetComponent<Dialogue2>();
        states = GameObject.Find("StateObject").GetComponent<States>();
        laylascene = GameObject.Find("Cutscene_Door").GetComponent<ContinueLaylaCutscene>();
        triggerc = GameObject.Find("TriggerCutscene");
    }

    // Update is called once per frame
    void Update()
    { 
        if(laylaCutscene && dialogue2.hasFinished)
        {
            laylascene.OpenDoor();
            triggerc.SetActive(false);
            StopAllCoroutines();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Dialogue1());
        
        states.currentState = States.PlayerStates.Cutscene;
    }

    public IEnumerator Dialogue1()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(dialogue2.Type());
        states.currentState = States.PlayerStates.DialogueState;
        laylaCutscene = true;
       
        

    }
}