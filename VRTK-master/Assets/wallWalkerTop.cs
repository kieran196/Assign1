using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallWalkerTop : MonoBehaviour {

    public GameObject world;
    private bool enteredLeft = false;
    private void OnCollisionEnter(Collision collision) {
        if(collision.transform.name.Contains("CameraRig") && walkState.state != walkState.WALK_STATES.TOP) {
            if(walkState.state == walkState.WALK_STATES.LEFT) {
                walkState.state = walkState.WALK_STATES.TOP;
                print("walkState changed:" + walkState.state);
                world.transform.RotateAround(collision.transform.position, collision.transform.parent.transform.right, 90f);
            } else if(walkState.state == walkState.WALK_STATES.RIGHT) {
                walkState.state = walkState.WALK_STATES.TOP;
                print("walkState changed:" + walkState.state);
                world.transform.RotateAround(collision.transform.position, collision.transform.parent.transform.right, -90f);
            } else if(walkState.state == walkState.WALK_STATES.FRONT) {
                walkState.state = walkState.WALK_STATES.TOP;
                print("walkState changed:" + walkState.state);
                world.transform.RotateAround(collision.transform.position, collision.transform.parent.transform.forward, -90f);
            }
        }
    }
}
