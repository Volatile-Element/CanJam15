using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WallThudAudio : MonoBehaviour {

    AudioSource audioSource;
    public List<AudioClip> wallThuds;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetAudioClip()
    {
        audioSource.clip = wallThuds[Random.Range(0, wallThuds.Count)];
    }
}
