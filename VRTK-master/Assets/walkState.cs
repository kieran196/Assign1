using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkState : MonoBehaviour {

    public enum WALK_STATES {FLOOR, LEFT, RIGHT, TOP, FRONT};
    public static WALK_STATES state;
    public static float counter;

}
