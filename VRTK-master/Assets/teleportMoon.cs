using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportMoon : MonoBehaviour {

    public GameObject cameraRig;
    public GameObject moonCam;

    void OnTriggerEnter(Collider collider) {
        print("collided:" + collider.name);
        if(collider.name.Contains("VRTK")) {
            cameraRig.transform.position = moonCam.transform.position;
        }
    }


}
