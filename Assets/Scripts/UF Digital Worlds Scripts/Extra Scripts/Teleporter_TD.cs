﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter_TD : MonoBehaviour {

    public GameObject tp1, tp2;
    private bool inArea = false;
    
    void Start() {
        tp1 = this.gameObject;
    }

    void OnTriggerEnter2D (Collider2D trig) {
        {
            trig.gameObject.transform.position = tp2.gameObject.transform.position;
        }
        
        
    }

   
}
