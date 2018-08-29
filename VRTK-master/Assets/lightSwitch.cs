using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightSwitch : MonoBehaviour {

    public SteamVR_TrackedObject trackedObjR;
    private SteamVR_Controller.Device deviceR;
    public SteamVR_TrackedObject trackedObjL;
    private SteamVR_Controller.Device deviceL;
    public GameObject[] switches;
    public bool switchesOn = true;
    private bool triggerExited = false;
    private void modifySwitches() {
        if (switchesOn == true) {
            foreach(GameObject switchObj in switches) {
                switchObj.SetActive(false);
                switchesOn = false;
            }
            print("switches turn off");
            return;
        } else if(switchesOn == false) {
            foreach(GameObject switchObj in switches) {
                switchObj.SetActive(true);
                switchesOn = true;
            }
            print("switches turn on");
            return;
        }
    }

    void OnTriggerStay(Collider collider) {
        if(collider.name == "Head" && deviceR != null && deviceR.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger) && triggerExited == true) {
            modifySwitches();
            triggerExited = false; ;
        } else if(collider.name == "Head" && deviceL != null && deviceL.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger) && triggerExited == true) {
            modifySwitches();
            triggerExited = false;
        }
    }

    private void OnTriggerExit(Collider other) {
        triggerExited = true;
    }

    // Update is called once per frame
    void Update () {
        if((int)trackedObjR.index != -1) {
            deviceR = SteamVR_Controller.Input((int)trackedObjR.index);
        }
        if((int)trackedObjL.index != -1) {
            deviceL = SteamVR_Controller.Input((int)trackedObjL.index);
        }
    }
}
