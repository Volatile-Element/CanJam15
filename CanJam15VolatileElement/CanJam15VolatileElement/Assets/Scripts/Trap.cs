using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour 
{
	public bool active = false;
	public ScoreManager scoreManager;
	public PartManager partManager;
	// Use this for initialization
	void Start () 
	{
		partManager = FindObjectOfType<PartManager> ();
		gameObject.GetComponent<Renderer>().material.color = partManager.colorCorners;
		scoreManager = FindObjectOfType<ScoreManager> ();
		toggleTrap ();
	}
	
	// Update is called once per frame
	void OnCollisionEnter () 
	{	
		if (active == true) 
		{
			scoreManager.penalty();
		}
	}

	public void toggleTrap()
	{
		active = !active;
		gameObject.GetComponent<Renderer> ().enabled = active;
		gameObject.GetComponent<Collider> ().enabled = active;
		StartCoroutine (Wait ());
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds (5.0f);
		toggleTrap ();
		Debug.Log ("Flippo");
	}
}
