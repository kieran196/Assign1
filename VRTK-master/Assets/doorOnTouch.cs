using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOnTouch : MonoBehaviour {

    public bool doorOpened = false;
    public GameObject door;

    private void OnTriggerEnter(Collider other) {
        if (other.transform.name == "Head" && doorOpened == false) {
            door.GetComponent<Animator>().SetTrigger("character_nearby");
            doorOpened = true;
            print("opened");
        } else if(other.transform.name == "Head" && doorOpened == true) {
            door.GetComponent<Animator>().ResetTrigger("character_nearby");
            doorOpened = false;
            print("closed");
        }
    }

}
