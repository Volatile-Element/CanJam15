using UnityEngine;
using System.Collections;

public class StraightPickup : PickupAbstract
{
	void start()
	{
		Debug.Log ("check");
		ChangeColor ();
        gameObject.GetComponentInChildren<Renderer>().material.color = partManager.colorStraights;
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.name == "Player") 
		{
			Triggers();
			destroyObject ();
		}
	}
	public override void Triggers()
	{
		Debug.Log ("Ok");
		partManager.NewSurface(PartManager.Showing.straights);
	}


}
