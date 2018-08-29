using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallWalkerFront : MonoBehaviour {

    public GameObject world;
    private void OnCollisionEnter(Collision collision) {
        if(collision.transform.name.Contains("CameraRig") && walkState.state != walkState.WALK_STATES.FRONT) {
            if(walkState.state == walkState.WALK_STATES.FLOOR || walkState.state == walkState.WALK_STATES.LEFT) {
                walkState.state = walkState.WALK_STATES.FRONT;
                print("walkState changed:" + walkState.state);
                world.transform.RotateAround(collision.transform.position, collision.transform.parent.transform.forward, -90f);
            } else if(walkState.state == walkState.WALK_STATES.TOP) {
                walkState.state = walkState.WALK_STATES.FRONT;
                print("walkState changed:" + walkState.state);
                world.transform.RotateAround(collision.transform.position, collision.transform.parent.transform.forward, 90f);
            } else if(walkState.state == walkState.WALK_STATES.RIGHT) {
                walkState.state = walkState.WALK_STATES.FRONT;
                print("walkState changed:" + walkState.state);
                world.transform.RotateAround(collision.transform.position, collision.transform.parent.transform.right, 90f);
            } /*else if(walkState.state == walkState.WALK_STATES.LEFT) {
                walkState.state = walkState.WALK_STATES.FRONT;
                print("walkState changed:" + walkState.state);
                //world.transform.RotateAround(collision.transform.position, collision.transform.parent.transform.right, -90f);
                Transform ogParent = collision.transform.parent;
                collision.transform.SetParent(world.transform);
                world.transform.position = new Vector3(0f, 0f, 0f);
                world.transform.eulerAngles = new Vector3(world.transform.eulerAngles.x, 0f, -90f);
                collision.transform.SetParent(ogParent);
            }*/
        }
    }
}
