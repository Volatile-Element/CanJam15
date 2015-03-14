using UnityEngine;
using System.Collections;

public class CornerPickup : PickupAbstract
{

	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.name == "Player") 
		{
			Color testColor = new Color (0, 0, 100, 1);
			ChangeColor (testColor);
			//destroyObject ();
		}
	}
	public override void Triggers()
	{
		Debug.Log ("Reached");
	}

}
