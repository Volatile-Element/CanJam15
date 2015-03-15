using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIM_MainMenu : MonoBehaviour
{
	public Canvas mainCanvas;
	public Canvas optionsCanvas;
	public Canvas startGameOptions;

	// Use this for initialization
	void Start ()
	{
		startGameOptions.transform.FindChild ("Panel/InputField - Width").GetComponent<InputField>().text = "20";
		startGameOptions.transform.FindChild ("Panel/InputField - Height").GetComponent<InputField> ().text = "20";
		startGameOptions.transform.FindChild ("Panel/InputField - Seed").GetComponent<InputField> ().text = Random.seed.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ShowStartGameOptions()
	{
		startGameOptions.enabled = true;
		mainCanvas.enabled = false;
	}

	public void HideStartGameOptions()
	{
		startGameOptions.enabled = false;
		mainCanvas.enabled = true;
	}

	public void StartGame()
	{
		int width = 0;
		int height = 0;
		int seed = 0;

		int.TryParse (startGameOptions.transform.FindChild ("Panel/InputField - Width").GetComponent<InputField> ().text, out width);
		int.TryParse (startGameOptions.transform.FindChild ("Panel/InputField - Height").GetComponent<InputField> ().text, out height);
		int.TryParse (startGameOptions.transform.FindChild ("Panel/InputField - Seed").GetComponent<InputField> ().text, out seed);

		if (width < 5)
			width = 5;

		if (height < 5)
			height = 5;

		PlayerPrefs.SetInt ("Width", width);
		PlayerPrefs.SetInt ("Height", height);
		PlayerPrefs.SetInt ("Seed", seed);

        Application.LoadLevelAsync("Ash Main");
		//Application.LoadLevel ("Ash Main");
	}

	public void ShowOptions()
	{
		optionsCanvas.enabled = true;
	}

	public void HideOptions()
	{
		optionsCanvas.enabled = false;
	}

	public void ExitMainMenu()
	{
		Application.Quit ();
	}
}
