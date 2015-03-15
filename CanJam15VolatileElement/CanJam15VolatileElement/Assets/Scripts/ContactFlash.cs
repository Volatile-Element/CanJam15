using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ContactFlash : MonoBehaviour {

    MeshRenderer mr;

    UnityEngine.Rendering.ShadowCastingMode previous;
    bool colliding = false;

    GameObject currentCollider;

	// Use this for initialization
	void Start () {
        mr = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (colliding)
        {
            if (currentCollider == null)
            {
                mr.shadowCastingMode = previous;
                colliding = false;
            }
        }
	}

    void OnCollisionEnter(Collision c)
    {
        if (!colliding && c.gameObject.GetComponent<CharControler>() != null)
        {
            previous = mr.shadowCastingMode;
            mr.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
            c.gameObject.GetComponent<WallThudAudio>().SetAudioClip();
            c.gameObject.GetComponent<AudioSource>().Play();
            colliding = true;

            currentCollider = c.gameObject;
        }

        if (!colliding && c.gameObject.GetComponent<BeamOrb>() != null)
        {
            colliding = true;
            previous = mr.shadowCastingMode;
            mr.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;

            currentCollider = c.gameObject;
        }
    }

    void OnCollisionExit(Collision c)
    {
        if (colliding)
        {
            mr.shadowCastingMode = previous;
            colliding = false;
        }
    }
}
