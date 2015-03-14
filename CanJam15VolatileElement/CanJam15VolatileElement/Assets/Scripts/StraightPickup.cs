using UnityEngine;
using System.Collections;

public class StraightPickup : PickupAbstract
{

	GameObject play;

	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.name == "Player") 
		{
			Color testColor = new Color (100, 100, 0, 0f);
			//ChangeColor (testColor);
			//destroyObject ();
			play = collision.collider.gameObject;

			collision.collider.GetComponent<TrailRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
		}
	}
	public override void Triggers()
	{
		Debug.Log ("Reached");
	}

	void Update()
	{
		if (Input.GetKeyDown("r"))
		{
			play.GetComponent<TrailRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
		}
	}



}
