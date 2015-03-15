using UnityEngine;
using System.Collections;

public class LightBeamPickup : PickupAbstract
{
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.name == "Player") 
		{
			collision.gameObject.AddComponent<BeamScatter>();
		}
	}

	public override void Triggers()
	{
		Debug.Log ("Ok");
		//partManager.NewSurface(PartManager.Showing.LightBeam);
	}
}
