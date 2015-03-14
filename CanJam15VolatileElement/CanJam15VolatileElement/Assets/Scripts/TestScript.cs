using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour 
{

    ColorPicker cp;

	// Use this for initialization
	void Start () 
    {
        cp = GameObject.Find("GameManager").GetComponent<ColorPicker>();



        this.GetComponent<Renderer>().material.color = cp.Picker();
	
	}
	
	// Update is called once per frame
	void Update () 
    {

        if (Input.GetKeyDown("d"))
        {
            this.GetComponent<Renderer>().material.color = cp.Picker();
        }
	
	}
}
