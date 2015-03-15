using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TeleporterManager : MonoBehaviour
{
	public GameObject usedParticleBurst;

	public List<TeleporterObject> teleporters = new List<TeleporterObject>();

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void AddTeleporter(TeleporterObject teleporter)
	{
		teleporters.Add (teleporter);
	}

	public void TeleportPlayer(TeleporterObject sender, GameObject player)
	{
		teleporters.Remove (sender);

		if (teleporters.Count == 0)
		{
			sender.DestroyTeleporter ();
			return;
		}

		TeleporterObject receiever = teleporters[Random.Range (0, teleporters.Count)];

		player.transform.position = new Vector3 (receiever.transform.position.x, player.transform.position.y, receiever.transform.position.z);

		sender.DestroyTeleporter ();
		receiever.DestroyTeleporter ();
	}
}
