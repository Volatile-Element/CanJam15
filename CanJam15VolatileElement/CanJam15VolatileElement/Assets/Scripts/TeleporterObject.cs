using UnityEngine;
using System.Collections;

public class TeleporterObject : MonoBehaviour
{
	TeleporterManager teleporterManager;

	// Use this for initialization
	void Start ()
	{
		teleporterManager = FindObjectOfType<TeleporterManager> ();
		teleporterManager.AddTeleporter (this);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.GetComponent<CharControler>() != null)
		{
			teleporterManager.TeleportPlayer (this, other.gameObject);
		}
	}

	public void DestroyTeleporter()
	{
		//Spawn Use Prefab
		Instantiate (teleporterManager.usedParticleBurst, transform.position, Quaternion.identity);

		//TODO: Play sound.

		Destroy (gameObject);
	}
}
