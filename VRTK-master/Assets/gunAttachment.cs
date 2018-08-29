using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunAttachment : MonoBehaviour {

    public SteamVR_TrackedObject trackedObjR;
    private SteamVR_Controller.Device deviceR;
    public SteamVR_TrackedObject trackedObjL;
    private SteamVR_Controller.Device deviceL;
    public bool gunAttached = false;
    private Transform oldParent;
    public GameObject gun;
    private float delay = 0f;
    private Vector3 oldPos;

    void OnTriggerStay(Collider collider) {
        if(collider.name == "Head" && deviceR != null && deviceR.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger) && delay >= 0.5f) {
            if (gunAttached == false) {
                oldParent = gun.transform.parent;
                gun.transform.SetParent(trackedObjR.transform);
                gun.transform.localPosition = new Vector3(0f, 0f, 0f);
                gun.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                print("gun attached");
                gunAttached = true;
                delay = 0f;
            } else if(gunAttached == true) {
                gunAttached = false;
                gun.transform.SetParent(oldParent);
                gun.transform.position = oldPos;
                print("gun detached");
                delay = 0f;
            }
        }
        if(collider.name == "Head" && deviceL != null && deviceL.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger) && delay >= 0.5f) {
            if(gunAttached == false) {
                oldParent = gun.transform.parent;
                gun.transform.SetParent(trackedObjL.transform);
                gun.transform.localPosition = new Vector3(0f, 0f, 0f);
                gun.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                print("gun attached");
                gunAttached = true;
                delay = 0f;
            } else if(gunAttached == true) {
                gunAttached = false;
                gun.transform.SetParent(oldParent);
                gun.transform.position = oldPos;
                print("gun detached");
                delay = 0f;
            }
        }
    }

    private void Start() {
        oldPos = gun.transform.position;
    }

    private void Update() {
        delay += Time.deltaTime;
        if((int)trackedObjR.index != -1) {
            deviceR = SteamVR_Controller.Input((int)trackedObjR.index);
        }
        if((int)trackedObjL.index != -1) {
            deviceL = SteamVR_Controller.Input((int)trackedObjL.index);
        }

    }
}
