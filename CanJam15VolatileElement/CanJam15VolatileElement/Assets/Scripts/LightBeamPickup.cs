using UnityEngine;
using System.Collections;

public class LightBeamPickup : PickupAbstract
{
	// Use this for initialization
	void Start ()
	{
        ChangeColor();
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
            collision.gameObject.GetComponent<CharControler>().alertText.text = "Beam active - Space to fire";
            Destroy(gameObject);
		}
	}

	public override void Triggers()
	{
		Debug.Log ("Ok");
		//partManager.NewSurface(PartManager.Showing.LightBeam);
	}
}
