using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupObject : MonoBehaviour {

    public SteamVR_TrackedObject trackedObjR;
    private SteamVR_Controller.Device deviceR;
    public SteamVR_TrackedObject trackedObjL;
    private SteamVR_Controller.Device deviceL;
    private Transform oldParent;
    private bool objectPickedUp = false;
    private bool pickUpMulti = false;
    private GameObject selectedObject;
    private bool xGravityStart;

    private void Start() {
        oldParent = this.transform.parent;
    }

    void pickup(SteamVR_TrackedObject trackedObj) {
        selectedObject = this.gameObject;
        if (this.gameObject.name == "NoGravity_Dice" || this.gameObject.name == "XGravity_Dice") {
            this.gameObject.GetComponent<Rigidbody>().useGravity = false;
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        } 
        this.transform.SetParent(trackedObj.transform);
        objectPickedUp = true;
        print("picked up " + this.name);
    }

    void drop(SteamVR_TrackedObject trackedObj) {
        if(pickUpMulti == false) {
            if(this.gameObject.name == "NoGravity_Dice" || this.gameObject.name == "XGravity_Dice") {
                this.gameObject.GetComponent<Rigidbody>().useGravity = true;
                this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            } if (this.gameObject.name == "XGravity_Dice") {
                this.gameObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(5f, 0f, 0f));
                xGravityStart = true;
            }
            this.transform.SetParent(oldParent);
            print("dropped " + this.name);
            objectPickedUp = false;
        } else if (pickUpMulti == true) {
            this.transform.SetParent(trackedObj.transform);

        }
    }

    void drop() {
        this.transform.SetParent(oldParent);
        print("dropped " + this.name);
        objectPickedUp = false;
    }

    private void OnTriggerEnter(Collider other) {
        //this.gameObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(1f, 0f, 0f));
        if (xGravityStart == true) {
            print("ended at:"+other.name);
            xGravityStart = false;
        }
    }

    void OnTriggerStay(Collider collider) {
        //print("colliding with.." + collider.name);
        if(collider.name == "Head" && deviceR != null && deviceR.GetTouch(SteamVR_Controller.ButtonMask.Trigger)) {
            if(objectPickedUp == false) {
                pickup(trackedObjR);
            }
        } else if(collider.name == "Head" && deviceL != null && deviceL.GetTouch(SteamVR_Controller.ButtonMask.Trigger)) {
            if(objectPickedUp == false) {
                pickup(trackedObjR);
            }
        }
    }

        // Update is called once per frame
    void Update () {
        if (xGravityStart == true) {
            //this.gameObject.transform.position += new Vector3(Time.deltaTime, 0f, 0f);
            //print("moving left..");
        }
        //print(objectPickedUp);
        if((int)trackedObjR.index != -1) {
            deviceR = SteamVR_Controller.Input((int)trackedObjR.index);
        }
        if((int)trackedObjL.index != -1) {
            deviceL = SteamVR_Controller.Input((int)trackedObjL.index);
        }
        if(deviceR != null && deviceR.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu)) {
            pickUpMulti = !pickUpMulti;
            if (pickUpMulti == false && objectPickedUp == true) {
                drop();
            }
        }
        if(deviceL != null && deviceL.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu)) {
            pickUpMulti = !pickUpMulti;
            if(pickUpMulti == false && objectPickedUp == true) {
                drop();
            }
        }
        if(deviceR != null && deviceR.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger) && objectPickedUp == true) {
            drop(trackedObjR);
        }
        if(deviceL != null && deviceL.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger) && objectPickedUp == true) {
            drop(trackedObjL);
        }
    }
}
