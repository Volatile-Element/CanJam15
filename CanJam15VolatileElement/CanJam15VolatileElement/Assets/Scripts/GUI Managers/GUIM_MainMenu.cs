using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIM_MainMenu : MonoBehaviour
{
	public Canvas mainCanvas;
	public Canvas optionsCanvas;
	public Canvas startGameOptions;
	public Canvas background;

	public Sprite[] backgroundImages;

	// Use this for initialization
	void Start ()
	{
		startGameOptions.transform.FindChild ("Panel/InputField - Width").GetComponent<InputField>().text = "20";
		startGameOptions.transform.FindChild ("Panel/InputField - Height").GetComponent<InputField> ().text = "20";
		startGameOptions.transform.FindChild ("Panel/InputField - Seed").GetComponent<InputField> ().text = Random.seed.ToString ();

		Texture2D[] textures = Resources.LoadAll<Texture2D> ("Sprites");

		backgroundImages = new Sprite[textures.Length];

		for (int i = 0; i < backgroundImages.Length; i++)
		{
			backgroundImages[i] = Sprite.Create (textures[i], new Rect(0, 0, textures[i].width, textures[i].height), Vector2.zero);
		}

		background.transform.FindChild ("Image - Background 1").GetComponent<Image> ().sprite = backgroundImages [Random.Range (0, backgroundImages.Length)];
		background.transform.FindChild ("Image - Background 2").GetComponent<Image> ().sprite = backgroundImages [Random.Range (0, backgroundImages.Length)];

		StartCoroutine (StayThenFade());
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

        Application.LoadLevelAsync("Main");
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

	private IEnumerator StayThenFade()
	{
		yield return new WaitForSeconds (2.5f);
		StartCoroutine (FadeBackgrounds ());
	}

	private IEnumerator FadeBackgrounds()
	{
		bool fading = true;

		while (fading)
		{
			yield return new WaitForSeconds (0.05f);

			Color currentColour = background.transform.FindChild ("Image - Background 1").GetComponent<Image> ().color;

			currentColour.a -= 0.005f;

			background.transform.FindChild ("Image - Background 1").GetComponent<Image> ().color = new Color (currentColour.r, currentColour.b, currentColour.b, currentColour.a);

			if (currentColour.a <= 0)
			{
				background.transform.FindChild ("Image - Background 1").GetComponent<Image> ().color = Color.white;
				background.transform.FindChild ("Image - Background 1").GetComponent<Image> ().sprite = background.transform.FindChild ("Image - Background 2").GetComponent<Image> ().sprite;
				background.transform.FindChild ("Image - Background 2").GetComponent<Image> ().sprite = backgroundImages [Random.Range (0, backgroundImages.Length)];
				fading = false;
				StartCoroutine (StayThenFade());
			}
		}
	}
}
