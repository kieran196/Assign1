using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveControlRoom : MonoBehaviour {

    public GameObject cameraRig;
    private bool inControlRoom = false;
    private bool flying = false;
    public GameObject controlRoom;
    public SteamVR_TrackedObject trackedObjR;
    private SteamVR_Controller.Device deviceR;
    public SteamVR_TrackedObject trackedObjL;
    private SteamVR_Controller.Device deviceL;
    private Transform startParent;
    private Vector3 oldPos;
    private float timer;
    public GameObject door;
    public GameObject leftTouchPadControl;
    // Use this for initialization
    void Start () {
        startParent = controlRoom.transform.parent;
        print("start parent:" + startParent);
        oldPos = controlRoom.transform.position;

    }

    private void OnTriggerEnter(Collider collider) {
            inControlRoom = true;
    }

    private void OnTriggerExit(Collider collider) {

    }

    private void flyY() {
        if(flying == true) {
            Vector2 touchpad = (deviceL.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0));
            if(touchpad.y > 0.7f) {
                cameraRig.transform.localPosition += new Vector3(0f, 0.05f, 0f);
            } else if(touchpad.y < -0.7f) {
                cameraRig.transform.localPosition -= new Vector3(0f, 0.05f, 0f);
            }
        }
    }

    void beginFlying() {
        if(deviceR != null && deviceR.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu) && inControlRoom == true && flying == false && timer >= 0.5f) {
            //print("Entered control room..");
            flying = true;
            leftTouchPadControl.SetActive(false);
            timer = 0f;
            if(cameraRig.GetComponent<Rigidbody>().useGravity == true) {
                cameraRig.GetComponent<Rigidbody>().useGravity = false;
            }
            if(controlRoom.transform.parent != cameraRig.transform) {
                controlRoom.transform.SetParent(cameraRig.transform);
            }
        } else if(deviceR != null && deviceR.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu) && inControlRoom == true && flying == true && timer >= 0.5f) {
            flying = false;
            leftTouchPadControl.SetActive(true);
            door.GetComponent<Animator>().SetTrigger("PlayerEntering");
            timer = 0f;
            if(cameraRig.GetComponent<Rigidbody>().useGravity == false) {
                cameraRig.GetComponent<Rigidbody>().useGravity = true;
            }
            controlRoom.transform.SetParent(startParent);
            controlRoom.transform.position = oldPos;
        }
        if(deviceL != null && deviceL.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu) && inControlRoom == true && flying == false && timer >= 0.5f) {
            //print("Entered control room..");
            flying = true;
            leftTouchPadControl.SetActive(false);
            timer = 0f;
            if(cameraRig.GetComponent<Rigidbody>().useGravity == true) {
                cameraRig.GetComponent<Rigidbody>().useGravity = false;
            }
            if(controlRoom.transform.parent != cameraRig.transform) {
                controlRoom.transform.SetParent(cameraRig.transform);
            }
        } else if(deviceL != null && deviceL.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu) && inControlRoom == true && flying == true && timer >= 0.5f) {
            flying = false;
            leftTouchPadControl.SetActive(true);
            door.GetComponent<Animator>().SetTrigger("PlayerEntering");
            timer = 0f;
            if(cameraRig.GetComponent<Rigidbody>().useGravity == false) {
                cameraRig.GetComponent<Rigidbody>().useGravity = true;
            }
            controlRoom.transform.SetParent(startParent);
            controlRoom.transform.position = oldPos;
        }
    }

        // Update is called once per frame
    void Update () {
        if((int)trackedObjR.index != -1) {
            deviceR = SteamVR_Controller.Input((int)trackedObjR.index);
        }
        if((int)trackedObjL.index != -1) {
            deviceL = SteamVR_Controller.Input((int)trackedObjL.index);
        }
        timer += Time.deltaTime;
        beginFlying();
        flyY();

    }
}
