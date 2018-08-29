using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class doorButton : MonoBehaviour {

    public VRTK_ControllerEvents controllerEvents;
    public VRTK.VRTK_InteractableObject linkedObject;
    public bool triggerButtonEvents = true;
    private bool doorOpened = false;
    public GameObject door;

    private void OnEnable() {
        controllerEvents = (controllerEvents == null ? GetComponent<VRTK.VRTK_ControllerEvents>() : controllerEvents);
        if(controllerEvents == null) {
            VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "VRTK_ControllerEvents_ListenerExample", "VRTK_ControllerEvents", "the same"));
            return;
        }

        //Setup controller event listeners
        controllerEvents.TriggerPressed += DoTriggerPressed;
    }

    private void OnDisable() {
        if(controllerEvents != null) {
            controllerEvents.TriggerPressed -= DoTriggerPressed;
        }
    }

    private void DoTriggerPressed(object sender, ControllerInteractionEventArgs e) {
        if(triggerButtonEvents && linkedObject.IsTouched() == true && doorOpened == false) {
            print("OPEN DOOR EVENT");
            doorOpened = true;
            door.GetComponent<Animator>().SetTrigger("character_nearby");
        }
    }

}
