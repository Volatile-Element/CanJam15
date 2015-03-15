using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Camera mainCamera;
    public int seed;
    public Canvas endGameCanvas;
    public Animator playerAnimator;
    public ScoreManager scoreManager;
    public PartManager partManager;

    bool gameStarted = false;

	// Use this for initialization
	void Awake () {
        seed = Random.seed;
        scoreManager = FindObjectOfType<ScoreManager>();
        partManager = FindObjectOfType<PartManager>();
	}
	
	// Update is called once per frame
	void Update () {

        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Decend"))
        {
            scoreManager.stopScore();
        }
        else if(!gameStarted)
        {
            scoreManager.startScore();
            gameStarted = true;
        }
	
	}

    public void SetCameraColour(Color value)
    {
        mainCamera.backgroundColor = value;
    }

    public void EndGame(double score)
    {
        endGameCanvas.enabled = true;
    }

    public void StartGame()
    {
        scoreManager.stopScore();

        playerAnimator.Play("Decend");
    }
}
