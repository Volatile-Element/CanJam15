using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

    GameManager gameManager;
    ScoreManager scoreManager;
    public Canvas EndGameCanvas;

	// Use this for initialization
	void Start () {
        gameManager = FindObjectOfType<GameManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision c)
    {
        gameManager.EndGame(scoreManager.score);
        c.collider.enabled = false;
        c.gameObject.GetComponent<CharControler>().enabled = false;
        scoreManager.stopScore();
        AcendSirKnight(c.gameObject);
    }

    void AcendSirKnight(GameObject g)
    {
       Animator animator = g.GetComponentInChildren<Animator>();
       animator.Play("Acend");
    }
}
