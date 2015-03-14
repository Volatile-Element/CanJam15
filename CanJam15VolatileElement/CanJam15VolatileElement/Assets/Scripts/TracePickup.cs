using UnityEngine;
using System.Collections;

public class TracePickup :PickupAbstract
{
	GameObject play;	


	void Start()
	{
		ChangeColor ();
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.name == "Player") 
		{
			Color randColor = colorPicker.Picker();
			play = collision.collider.gameObject;
			collision.collider.GetComponent<TrailRenderer>().material.color = randColor;
			collision.collider.GetComponent<TrailRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
			Destroy(gameObject);
		}
	}
	public override void Triggers()
	{
		//Necessary override
	}

}
