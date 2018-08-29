using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityTrigger : MonoBehaviour {

    public GameObject cameraRig;
    public SteamVR_TrackedObject trackedObjR;
    private SteamVR_Controller.Device deviceR;
    public SteamVR_TrackedObject trackedObjL;
    private SteamVR_Controller.Device deviceL;
    public GameObject bodyPhysics;
    public GameObject headsetCollision;
    public GameObject leftTouchPadControl;
    private float timer = 0f;

    /*private void OnTriggerStay(Collider other) {
        if(other.name.Contains("[VRTK][AUTOGEN]")) {
            if(gravityHandler.gravityEnabled == false) {
                bodyPhysics.SetActive(false);
                headsetCollision.SetActive(false);
                gravityHandler.gravityEnabled = true;
            }
            //gravityHandler.gravityEnabled = true;
        }
    }*/

    void Update() {
        timer += Time.deltaTime;
        if((int)trackedObjR.index != -1) {
            deviceR = SteamVR_Controller.Input((int)trackedObjR.index);
        }
        if((int)trackedObjL.index != -1) {
            deviceL = SteamVR_Controller.Input((int)trackedObjL.index);
        }
    }

    void OnTriggerStay(Collider collider) {
        //print("colliding with.." + collider.name);
        if(collider.name == "Head" && deviceR != null && deviceR.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger) && timer >= 0.5f) {
            if(gravityHandler.gravityEnabled == false) {
                bodyPhysics.SetActive(false);
                headsetCollision.SetActive(false);
                leftTouchPadControl.SetActive(false);
                timer = 0f;
                this.GetComponent<Toggle>().isOn = true;
                Destroy(cameraRig.GetComponent<Rigidbody>());
                gravityHandler.gravityEnabled = true;
            } else if(gravityHandler.gravityEnabled == true) {
                gravityHandler.gravityEnabled = false;
                this.GetComponent<Toggle>().isOn = false;
                leftTouchPadControl.SetActive(true);
            }
        }
        if(collider.name == "Head" && deviceL != null && deviceL.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger) && timer >= 0.5f) {
            if(gravityHandler.gravityEnabled == false) {
                bodyPhysics.SetActive(false);
                headsetCollision.SetActive(false);
                leftTouchPadControl.SetActive(false);
                timer = 0f;
                this.GetComponent<Toggle>().isOn = true;
                Destroy(cameraRig.GetComponent<Rigidbody>());
                gravityHandler.gravityEnabled = true;
            } else if(gravityHandler.gravityEnabled == true) {
                gravityHandler.gravityEnabled = false;
                this.GetComponent<Toggle>().isOn = false;
                leftTouchPadControl.SetActive(true);
            }
        }
    }

    // Update is called once per frame


}
