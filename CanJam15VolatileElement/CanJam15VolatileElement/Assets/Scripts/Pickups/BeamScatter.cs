using UnityEngine;
using System.Collections;

public class BeamScatter : MonoBehaviour
{
	public GameObject orbsToThrow;

	// Use this for initialization
	void Start () {
		ThrowOrbs (1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ThrowOrbs(int amount)
	{
		for (int i = 0; i < amount; i++)
		{
			GameObject orb = (GameObject)Instantiate(orbsToThrow, transform.position, Quaternion.identity);
			orb.GetComponent<Rigidbody>().AddForce (transform.forward * 150);
		}
	}
}
