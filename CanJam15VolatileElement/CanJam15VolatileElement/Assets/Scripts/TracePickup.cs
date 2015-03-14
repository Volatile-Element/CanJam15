using UnityEngine;
using System.Collections;

public class TracePickup :PickupAbstract
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
			
			collision.collider.GetComponent<TrailRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
		}
	}

	public override void Triggers()
	{

	}

	void Update()
	{
		if (Input.GetKeyDown("d"))
		{
			play.GetComponent<TrailRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
		}
	}
}
