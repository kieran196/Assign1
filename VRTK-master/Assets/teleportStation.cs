﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportStation : MonoBehaviour {

    public GameObject cameraRig;
    public GameObject stationCam;

    void OnTriggerEnter(Collider collider) {
        print("collided:" + collider.name);
        if(collider.name.Contains("VRTK")) {
            cameraRig.transform.position = stationCam.transform.position;
        }
    }

}
