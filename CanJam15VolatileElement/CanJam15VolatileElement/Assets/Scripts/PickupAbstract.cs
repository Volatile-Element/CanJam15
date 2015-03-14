using UnityEngine;
using System.Collections;

public abstract class PickupAbstract : MonoBehaviour 
{
	public Material color;
	public void ChangeColor(Color colorChoice)
	{
		MeshRenderer gameObjectRenderer = gameObject.GetComponent<MeshRenderer>();
		
		color.color = colorChoice;
		gameObjectRenderer.material = color;
	}

	public void destroyObject()
	{
		Destroy (gameObject);
	}

	public abstract void Triggers();

}
