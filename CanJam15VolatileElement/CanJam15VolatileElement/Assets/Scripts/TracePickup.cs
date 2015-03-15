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
            partManager.NewSurface(PartManager.Showing.trail);
            collision.gameObject.GetComponent<CharControler>().alertText.text = "Trace - M to activate";
			//collision.collider.GetComponent<TrailRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
			Destroy(gameObject);
		}
	}
	public override void Triggers()
	{
		//Necessary override
	}

}
