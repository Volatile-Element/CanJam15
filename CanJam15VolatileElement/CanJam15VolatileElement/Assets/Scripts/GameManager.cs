using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public Camera mainCamera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetCameraColour(Color value)
    {
        mainCamera.backgroundColor = value;
    }
}
