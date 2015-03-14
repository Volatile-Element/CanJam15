using UnityEngine;
using System.Collections;

public class TestPlayer : MonoBehaviour 
{
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown("d"))
		{
			gameObject.transform.Translate(Vector3.forward);
		}
		if(Input.GetKeyDown("w"))
		{
			gameObject.transform.Translate(Vector3.left);
		}

		if(Input.GetKeyDown("s"))
		{
			gameObject.transform.Translate(Vector3.right);
		}
		if(Input.GetKeyDown("a"))
		{
			gameObject.transform.Translate(Vector3.back);
		}
	}
}
