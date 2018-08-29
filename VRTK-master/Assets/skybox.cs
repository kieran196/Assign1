using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skybox : MonoBehaviour {

    //public Material[] skyBoxMaterial;
    //public Vector3[] sunPosition;
    public Material skyBoxMaterial;
    public Vector3 sunPosition;
    private int skyBoxLength = 0;
    private int currentSkyBoxIndex = 0;
    public GameObject sun;

    // Use this for initialization
    void Start () {
        RenderSettings.skybox = skyBoxMaterial;
        sun.transform.eulerAngles = sunPosition;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
