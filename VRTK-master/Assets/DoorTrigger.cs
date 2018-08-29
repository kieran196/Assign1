using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour {

    public GameObject door;
    public static bool inControlRoom = false;
    public doorButtonManager doorManager;

    private void OnTriggerEnter(Collider collider) {
        if(collider.name.Contains("[VRTK][AUTOGEN]") && door.name == "glass_door1") {
            door.GetComponent<Animator>().SetTrigger("character_nearby");
        } else if(collider.name.Contains("[VRTK][AUTOGEN]") && door.name == "controlRoomDoor") {
            door.GetComponent<Animator>().SetTrigger("PlayerEntering");
        } else if(collider.name.Contains("[VRTK][AUTOGEN]") && door.name == "glassDoor2" && doorManager.doorOpened == true) {
            doorManager.doorOpened = false;
            door.GetComponent<Animator>().ResetTrigger("character_nearby");
            print("door closed");
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.name.Contains("[VRTK][AUTOGEN]") && door.name == "glass_door1") {
            door.GetComponent<Animator>().ResetTrigger("character_nearby");
        } else if (collider.name.Contains("[VRTK][AUTOGEN]") && door.name == "controlRoomDoor") {
            door.GetComponent<Animator>().ResetTrigger("PlayerEntering");
            //inControlRoom = true;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
