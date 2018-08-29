using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderChanger : MonoBehaviour {

    public SteamVR_TrackedObject trackedObjR;
    public SteamVR_TrackedObject trackedObjL;
    private SteamVR_Controller.Device deviceR;
    private SteamVR_Controller.Device deviceL;
    public GameObject pointLights;

    public void dimLights(float value) {
        float modValue = value * 5f;
        foreach (Transform light in pointLights.transform) {
            light.GetComponent<Light>().intensity = modValue;
        }
    }



    protected virtual void OnTriggerStay(Collider collider) {
        if (collider.name == "Head" && deviceR != null && deviceR.GetPress(SteamVR_Controller.ButtonMask.Trigger)) {
            this.GetComponent<Slider>().value = collider.transform.position.z + 2.25f;
            //print(collider.transform.position);
            dimLights(this.GetComponent<Slider>().value);
        }
        if(collider.name == "Head" && deviceL != null && deviceL.GetPress(SteamVR_Controller.ButtonMask.Trigger)) {
            this.GetComponent<Slider>().value = collider.transform.position.z + 2.25f;
            dimLights(this.GetComponent<Slider>().value);
        }
        //print(collider.name);
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
