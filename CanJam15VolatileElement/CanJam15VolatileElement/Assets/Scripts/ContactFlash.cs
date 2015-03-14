using UnityEngine;
using System.Collections;

public class ContactFlash : MonoBehaviour {

    MeshRenderer mr;

	// Use this for initialization
	void Start () {
        mr = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision c)
    {
        mr.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
    }

    void OnCollisionExit(Collision c)
    {
        mr.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
    }
}
