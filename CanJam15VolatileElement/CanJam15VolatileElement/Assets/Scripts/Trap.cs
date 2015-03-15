using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour 
{
	public bool active = false;
	public ScoreManager scoreManager;
	public PartManager partManager;
	public GameObject gObject;

	bool punishedPlayer = false;

	// Use this for initialization
	void Start () 
	{
		gObject = transform.Find ("DangerPart").gameObject;
		partManager = FindObjectOfType<PartManager> ();
		//gameObject.GetComponent<Renderer>().material.color = partManager.colorTraps;
		scoreManager = FindObjectOfType<ScoreManager> ();
		toggleTrap ();
	}
	
//	// Update is called once per frame
//	void OnCollisionEnter () 
//	{	
//		if (active == true) 
//		{
//			scoreManager.penalty();
//		}
//	}

	public void toggleTrap()
	{
		active = !active;
		gObject.SetActive (active);
		punishedPlayer = false;
		StartCoroutine (Wait());
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds (5.0f);
		toggleTrap ();
		Debug.Log ("Flippo");
	}

	void OnTriggerEnter(Collider other)
	{
		if (active)
		{
			if (other.gameObject.GetComponent<CharControler>() != null)
			{
				scoreManager.penalty();
				punishedPlayer = true;
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (active && !punishedPlayer)
		{
			if (other.gameObject.GetComponent<CharControler>() != null)
			{
				scoreManager.penalty();
				punishedPlayer = true;
			}
		}
	}
}
