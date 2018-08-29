using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gravityHandler : MonoBehaviour {
    public GameObject cameraRig;
    public GameObject cameraEyes;
    public GameObject bodyPhysics;
    public GameObject headsetCollision;
    public SteamVR_TrackedObject trackedObjR;
    private SteamVR_Controller.Device deviceR;
    public SteamVR_TrackedObject trackedObjL;
    private SteamVR_Controller.Device deviceL;
    public GameObject toggle;

    public static bool gravityEnabled = false;
    Vector3 moveInput;
    Vector3 rotInput;
    float speed = 150;

    public bool getGravityEnabled() {
        return gravityEnabled;
    }

    private void getMovementVector() {
        float tiltAroundY;
        float tiltAroundX;
        Vector2 touchpad = (deviceL.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0));
        if(touchpad.y > 0.7f) {
            tiltAroundY = deviceL.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).y;
            cameraRig.transform.Rotate(0, tiltAroundY, 0);
        } else if(touchpad.y < -0.7f) {
            tiltAroundY = deviceL.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).y;
            cameraRig.transform.Rotate(0, tiltAroundY, 0);
        } else if(touchpad.x > 0.7f) {
            tiltAroundX = deviceL.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).x;
            cameraRig.transform.Rotate(tiltAroundX, 0, 0);
        } else if(touchpad.x < -0.7f) {
            tiltAroundX = deviceL.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).x;
            cameraRig.transform.Rotate(tiltAroundX, 0, 0);
        }
    }

    public void enableGravity() {
        print("Gravity enabled");
        cameraRig.AddComponent<Rigidbody>();
        cameraRig.GetComponent<Rigidbody>().mass = 2;
        cameraRig.GetComponent<Rigidbody>().drag = 20;
        cameraRig.GetComponent<Rigidbody>().angularDrag = 10;
        cameraRig.GetComponent<Rigidbody>().useGravity = false;
        cameraRig.GetComponent<Rigidbody>().isKinematic = false;
        cameraRig.AddComponent<CapsuleCollider>();
        cameraRig.GetComponent<CapsuleCollider>().isTrigger = false;
        cameraRig.GetComponent<CapsuleCollider>().radius = 0.5f;
        cameraRig.GetComponent<CapsuleCollider>().height = 2f;
    }

    public void disableGravity() {
        if(gravityEnabled == true) {
            print("Gravity disabled");
            toggle.GetComponent<Toggle>().isOn = false;
            cameraRig.GetComponent<Rigidbody>().mass = 100f;
            cameraRig.GetComponent<Rigidbody>().drag = 0f;
            cameraRig.GetComponent<Rigidbody>().angularDrag = 0.05f;
            cameraRig.GetComponent<Rigidbody>().useGravity = true;
            cameraRig.GetComponent<Rigidbody>().isKinematic = false;
            cameraRig.GetComponent<Rigidbody>().freezeRotation = true;
            Destroy(cameraRig.GetComponent<CapsuleCollider>());
            gravityEnabled = false;
            bodyPhysics.SetActive(true);
            headsetCollision.SetActive(true);
            //cameraRig.transform.localPosition = new Vector3(0f, 0f, 0f);
            cameraRig.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        }
    }

    void Update() {
        if((int)trackedObjR.index != -1) {
            deviceR = SteamVR_Controller.Input((int)trackedObjR.index);
        }
        if((int)trackedObjL.index != -1) {
            deviceL = SteamVR_Controller.Input((int)trackedObjL.index);
        }

        if(gravityEnabled == true && cameraRig.GetComponent<Rigidbody>() == null) {
            enableGravity();
        }
        if (gravityEnabled == true) {
            getMovementVector();
        }
        if(deviceR != null && deviceR.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu) && gravityEnabled == true) {
            disableGravity();
        }
        if(deviceL != null && deviceL.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu) && gravityEnabled == true) {
            disableGravity();
        }

    }
}
