using UnityEngine;
using System.Collections;

public class DoorPickup : PickupAbstract
{
	void start()
	{
		Debug.Log ("check");
		ChangeColor ();
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
		partManager.NewSurface(PartManager.Showing.doors);
	}
}
