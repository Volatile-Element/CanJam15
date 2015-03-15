using UnityEngine;
using System.Collections;

public class StraightPickup : PickupAbstract
{
	void Start()
	{
		Debug.Log ("check");
		//ChangeColor ();
        gameObject.GetComponentInChildren<Renderer>().material.color = partManager.colorStraights;
        gameObject.GetComponentInChildren<Light>().color = partManager.colorStraights;
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.name == "Player") 
		{
            collision.gameObject.GetComponent<CharControler>().alertText.text = "Walls Active";
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
