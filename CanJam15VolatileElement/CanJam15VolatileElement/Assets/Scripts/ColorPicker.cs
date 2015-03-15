using UnityEngine;
using System.Collections;

public class ColorPicker : MonoBehaviour 
{
    GameManager gameManager;

	// Use this for initialization
	void Start () 
    {
        gameManager = FindObjectOfType<GameManager>();
        Random.seed = gameManager.seed;
	}

    public Color Picker()
    {
        Color temp = new Color(Random.Range(0.0f,1.0f), Random.Range(0.0f,1.0f), Random.Range(0.0f,1.0f), 1);
        return temp;
    }
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
