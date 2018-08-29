using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class masterLightsChanger : MonoBehaviour {

    public SteamVR_TrackedObject trackedObjR;
    private SteamVR_Controller.Device deviceR;
    public SteamVR_TrackedObject trackedObjL;
    private SteamVR_Controller.Device deviceL;
    public GameObject lights;
    private bool lightsActive = true;
    private float timer = 0f;
    private void lightsOut() {
        print("Lights off..");
        timer = 0f;
        lightsActive = false;
        this.GetComponent<Toggle>().isOn = false;
        foreach (Transform light in lights.transform) {
            if (light.gameObject.activeInHierarchy == true) {
                light.gameObject.SetActive(false);
            }
        }
    }

    private void lightsOn() {
        print("Lights on..");
        timer = 0f;
        lightsActive = true;
        this.GetComponent<Toggle>().isOn = true;
        foreach(Transform light in lights.transform) {
            if(light.gameObject.activeInHierarchy == false) {
                light.gameObject.SetActive(true);
            }
        }
    }

    void OnTriggerStay(Collider collider) {
        //print("colliding with.." + collider.name);
        if(collider.name == "Head" && deviceR != null && deviceR.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger) && timer >= 0.5f) {
            if(lightsActive == false) {
                lightsOn();
            } else if(lightsActive == true) {
                lightsOut();
            }
        }
        if(collider.name == "Head" && deviceL != null && deviceL.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger) && timer >= 0.5f) {
            if(lightsActive == false) {
                lightsOn();
            } else if(lightsActive == true) {
                lightsOut();
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if((int)trackedObjR.index != -1) {
            deviceR = SteamVR_Controller.Input((int)trackedObjR.index);
        }
        if((int)trackedObjL.index != -1) {
            deviceL = SteamVR_Controller.Input((int)trackedObjL.index);
        }
    }
}
