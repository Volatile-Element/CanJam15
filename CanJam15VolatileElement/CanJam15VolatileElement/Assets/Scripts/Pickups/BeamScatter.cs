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
		orbsToThrow = Resources.Load<GameObject> ("Prefabs/Beam Orb") as GameObject;
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
			Transform spawn = transform.Find ("Spawn for Player Objects").transform;

			GameObject orb = (GameObject)Instantiate(orbsToThrow, new Vector3(spawn.position.x, spawn.position.y, spawn.position.z), Quaternion.identity);

			orb.GetComponent<Rigidbody>().AddForce (-spawn.forward * 50);
		}

		if (uses > maxUses)
			Destroy (this);
	}
}
