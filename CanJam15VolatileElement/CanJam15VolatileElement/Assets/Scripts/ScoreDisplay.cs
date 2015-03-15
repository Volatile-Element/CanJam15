using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    ScoreManager scoreManager;
    public Text scoreDisplay;

	// Use this for initialization
	void Start () {
        scoreManager = FindObjectOfType<ScoreManager>();
	
	}
	
	// Update is called once per frame
	void Update () {
        scoreDisplay.text = scoreManager.score.ToString();
	}
}
