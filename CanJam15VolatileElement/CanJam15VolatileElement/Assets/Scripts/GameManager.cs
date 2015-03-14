using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public Camera mainCamera;
    public int seed;

	// Use this for initialization
	void Awake () {
        seed = Random.seed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetCameraColour(Color value)
    {
        mainCamera.backgroundColor = value;
    }
}
