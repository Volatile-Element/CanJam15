using UnityEngine;
using System.Collections;

public class ContactFlash : MonoBehaviour {

    MeshRenderer mr;

    UnityEngine.Rendering.ShadowCastingMode previous;
    bool colliding = false;

	// Use this for initialization
	void Start () {
        mr = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision c)
    {
        if (!colliding)
        {
            previous = mr.shadowCastingMode;
            mr.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
            colliding = true;
        }
    }

    void OnCollisionExit(Collision c)
    {
        mr.shadowCastingMode = previous;
        colliding = false;
    }
}
