using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    GUIM_PauseMenu guiPauseMenu;

    public Camera mainCamera;
    public int seed;
    public Canvas endGameCanvas;
    public Animator playerAnimator;
    public ScoreManager scoreManager;
    public PartManager partManager;
    public GameObject light;

    bool gameStarted = false;

	// Use this for initialization
	void Awake () {
        seed = PlayerPrefs.GetInt("Seed");
        //GameObject innerLight = (GameObject)Instantiate(light);
        scoreManager = FindObjectOfType<ScoreManager>();
        partManager = FindObjectOfType<PartManager>();
        guiPauseMenu = FindObjectOfType<GUIM_PauseMenu>();
	}
	
	// Update is called once per frame
	void Update () {

        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Decend"))
        {
            scoreManager.stopScore();
            gameStarted = false;
        }
        else if(!gameStarted)
        {
            scoreManager.startScore();
            partManager.ResetCorners();
            partManager.ResetStraights();
            gameStarted = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!guiPauseMenu.pauseMenuCanvas.enabled)
                guiPauseMenu.Pause();
            else
                guiPauseMenu.Continue();
        }
	
	}

    public void SetCameraColour(Color value)
    {
        mainCamera.backgroundColor = value;
    }

    public void EndGame(double score)
    {
        endGameCanvas.enabled = true;
        GameObject.Find("Player").GetComponent<TrailRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
		partManager.UpdateCorners ();
		partManager.UpdateStraights ();
    }

    public void StartGame()
    {
        playerAnimator.Play("Decend");
        partManager.RowShower();
    }

    public void QuitToMenu()
    {
        PlayerPrefs.SetInt("ThisGame", (int)scoreManager.score);
        Application.LoadLevel("Main Menu");

    }

    public void Restart()
    {
        Application.LoadLevel("Main");
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("Seed", Random.Range(0, 9999));
        Application.LoadLevel("Main");
    }
}
