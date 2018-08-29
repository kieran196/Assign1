using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallWalkerRight : MonoBehaviour {

    public GameObject world;
    private bool enteredLeft = false;
    private void OnCollisionEnter(Collision collision){
        if (collision.transform.name.Contains("CameraRig") && walkState.state != walkState.WALK_STATES.RIGHT) {
            if(walkState.state == walkState.WALK_STATES.FLOOR) {
                walkState.state = walkState.WALK_STATES.RIGHT;
                print("walkState changed:" + walkState.state);
                world.transform.RotateAround(collision.transform.position, collision.transform.parent.transform.right, -90f);
            } else if(walkState.state == walkState.WALK_STATES.TOP) {
                walkState.state = walkState.WALK_STATES.RIGHT;
                print("walkState changed:" + walkState.state);
                world.transform.RotateAround(collision.transform.position, collision.transform.parent.transform.right, 90f);
            } else if(walkState.state == walkState.WALK_STATES.FRONT) {
                walkState.state = walkState.WALK_STATES.RIGHT;
                print("walkState changed:" + walkState.state);
                world.transform.RotateAround(collision.transform.position, collision.transform.parent.transform.right, 90f);
                world.transform.RotateAround(collision.transform.position, collision.transform.parent.transform.forward, 90f);
            }
        }
    }
}
