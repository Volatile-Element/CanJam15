using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIM_PauseMenu : MonoBehaviour
{
	public Canvas pauseMenuCanvas;
	int seed = 0;

	// Use this for initialization
	void Start ()
	{
        seed = PlayerPrefs.GetInt("Seed");
        pauseMenuCanvas.transform.Find("Text - Seed").GetComponent<Text>().text = "Seed: " + seed.ToString();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void Continue()
	{
		HidePauseMenu ();

		Time.timeScale = 1;
	}

	public void Pause()
	{
		ShowPauseMenu ();

		Time.timeScale = 0;
	}

	public void HidePauseMenu()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

		pauseMenuCanvas.enabled = false;
	}

	public void ShowPauseMenu()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		
		pauseMenuCanvas.enabled = true;
	}

	public void ReturnToMainMenu()
	{
        Time.timeScale = 1;
		Application.LoadLevel ("Main Menu");
	}

	public void Quit()
	{
        Time.timeScale = 1;
		Application.Quit ();
	}
}
