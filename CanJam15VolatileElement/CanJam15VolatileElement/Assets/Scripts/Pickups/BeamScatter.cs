using UnityEngine;
using System.Collections;

public class BeamScatter : MonoBehaviour
{
	public GameObject orbsToThrow;

	public int maxUses = 5;
	public int uses = 0;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space))
			ThrowOrbs (1);
	}

	public void ThrowOrbs(int amount)
	{
		uses++;

		for (int i = 0; i < amount; i++)
		{
			GameObject orb = (GameObject)Instantiate(orbsToThrow, transform.position, Quaternion.identity);
			orb.GetComponent<Rigidbody>().AddForce (transform.forward * 150);
		}

		if (uses > maxUses)
			Destroy (this);
	}
}
