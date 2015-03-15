using UnityEngine;
using System.Collections;

public class CornerPickup : PickupAbstract
{
	void Start()
	{
		Debug.Log ("check");
		//ChangeColor ();
        gameObject.GetComponentInChildren<Renderer>().material.color = partManager.colorCorners;
        gameObject.GetComponentInChildren<Light>().color = partManager.colorCorners;
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.name == "Player") 
		{
			Triggers();
            collision.gameObject.GetComponent<CharControler>().alertText.text = "Corners Active";
			destroyObject ();
		}
	}
	public override void Triggers()
	{
		Debug.Log ("Ok");
		partManager.NewSurface(PartManager.Showing.corners);
	}

}
