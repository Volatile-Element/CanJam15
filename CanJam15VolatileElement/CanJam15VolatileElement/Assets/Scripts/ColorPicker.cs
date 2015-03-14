using UnityEngine;
using System.Collections;

public class ColorPicker : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {
	
	}

    public Color Picker()
    {
        Color temp = new Color(Random.Range(0.0f,1.1f), Random.Range(0.0f,1.1f), Random.Range(0.0f,1.1f), 1);
        return temp;
    }
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
