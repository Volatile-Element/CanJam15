using UnityEngine;
using System.Collections;

public abstract class PickupAbstract : MonoBehaviour 
{
	public Material color;
	public PartManager partManager;
	void start()
	{
		partManager = FindObjectOfType<PartManager> ();
	}
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
