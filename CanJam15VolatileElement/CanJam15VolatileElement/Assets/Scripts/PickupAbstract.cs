using UnityEngine;
using System.Collections;

public abstract class PickupAbstract : MonoBehaviour 
{
	public PartManager partManager;
	public ColorPicker colorPicker;
	void Awake()
	{
		partManager = FindObjectOfType<PartManager> ();
		colorPicker = FindObjectOfType<ColorPicker> ();
	}
	public void ChangeColor()
	{
		Color randColor = colorPicker.Picker ();
		gameObject.GetComponentInChildren<Light> ().color = randColor;
        gameObject.GetComponentInChildren<Renderer>().material.color = randColor;
//		Debug.Log (randColor.ToString ());
	}

	public void destroyObject()
	{
		Destroy (gameObject);
	}

	public abstract void Triggers();

}
