using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOnHandle : MonoBehaviour {
    public SteamVR_TrackedObject trackedObjR;
    private SteamVR_Controller.Device deviceR;
    public SteamVR_TrackedObject trackedObjL;
    private SteamVR_Controller.Device deviceL;

    public GameObject door;

    void OnTriggerStay(Collider collider) {
        print("colliding with.." + collider.name);
        if(collider.name == "Head" && deviceR != null && deviceR.GetTouch(SteamVR_Controller.ButtonMask.Trigger)) {
            Vector3 targetDir = new Vector3(0f,0f,0f);
            if(this.name == "Handle_ColliderR") {
                targetDir = trackedObjR.transform.position + door.transform.position;
            } else if(this.name == "Handle_ColliderL") {
                targetDir = trackedObjR.transform.position - door.transform.position;
            }
                float step = 1f * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            door.transform.rotation = Quaternion.LookRotation(newDir);
            door.transform.eulerAngles = new Vector3(0f, door.transform.eulerAngles.y, 0f);
        }
        if(collider.name == "Head" && deviceL != null && deviceL.GetTouch(SteamVR_Controller.ButtonMask.Trigger)) {
            Vector3 targetDir = new Vector3(0f, 0f, 0f);
            if(this.name == "Handle_ColliderR") {
                targetDir = trackedObjL.transform.position + door.transform.position;
            } else if(this.name == "Handle_ColliderL") {
                targetDir = trackedObjL.transform.position - door.transform.position;
            }
            float step = 1f * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            door.transform.rotation = Quaternion.LookRotation(newDir);
            door.transform.eulerAngles = new Vector3(0f, door.transform.eulerAngles.y, 0f);
        }
    }

    private void Update() {
        if((int)trackedObjR.index != -1) {
            deviceR = SteamVR_Controller.Input((int)trackedObjR.index);
        }
        if((int)trackedObjL.index != -1) {
            deviceL = SteamVR_Controller.Input((int)trackedObjL.index);
        }
    }
}
