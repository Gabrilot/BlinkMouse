using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	public string quit;	
	public bool isPaused;
	public GameObject pauseMenuCanvas;
	Teleporter teleport;
	Controller2D soric;
	PlayerPhysics soric1;

	public GameObject mainPauseHolder;
	public GameObject optionsHolder;

	public Slider[] volumeSliders;
	public Toggle[] resolutionToggles;
	public Toggle fullscreenToggle;
	public int[] screenWidths;
	int activeScreenResIndex;

	void Start(){
		teleport = FindObjectOfType<Teleporter> ();
		soric = FindObjectOfType<Controller2D> ();
		soric1 = FindObjectOfType<PlayerPhysics> ();

		activeScreenResIndex = PlayerPrefs.GetInt ("screen res index");
		bool isFullscreen = (PlayerPrefs.GetInt ("fullscreen") == 1)?true:false;


		for (int i = 0; i < resolutionToggles.Length; i++) {
			resolutionToggles [i].isOn = i == activeScreenResIndex;
		}
	}

	
	void Update () {
		
		if (isPaused){	
			pauseMenuCanvas.SetActive(true);
			Time.timeScale = 0f;
			teleport.enabled = false;
			soric.enabled = false;
			soric1.enabled = false;


		
		}else{			
			pauseMenuCanvas.SetActive(false);
			Time.timeScale = 1f;
			teleport.enabled = true;
			soric.enabled = true;
			soric1.enabled = true;
		}
	
		if (Input.GetKeyDown(KeyCode.Escape)){
			

			isPaused = !isPaused;
		}
	}
	
	public void Resume(){
		Application.LoadLevel ("MainMenu");
	}

	public void OptionsMenu() {
		mainPauseHolder.SetActive (false);
		optionsHolder.SetActive (true);
	}

	public void MainPauseMenu() {
		mainPauseHolder.SetActive (true);
		optionsHolder.SetActive (false);
	}
	
	public void Reload(){
		Application.LoadLevel(Application.loadedLevel);
	}
	
	public void Quit(){
		Application.Quit();	
	}


	public void SetScreenResolution(int i) {
		if (resolutionToggles [i].isOn) {
			activeScreenResIndex = i;
			float aspectRatio = 16 / 9f;
			Screen.SetResolution (screenWidths [i], (int)(screenWidths [i] / aspectRatio), false);
			PlayerPrefs.SetInt ("screen res index", activeScreenResIndex);
			//PlayerPrefs.Save ();
		}
	}

	public void SetFullscreen(bool isFullscreen) {
		/*for (int i = 0; i < resolutionToggles.Length; i++) {
			resolutionToggles [i].interactable = !isFullscreen;
		}*/

		if (isFullscreen) {
			Resolution[] allResolutions = Screen.resolutions;
			Resolution maxResolution = allResolutions [allResolutions.Length - 1];
			Screen.SetResolution (maxResolution.width, maxResolution.height, true);
			Screen.fullScreen = fullscreenToggle.isOn;
		} else {
			Screen.fullScreen = !fullscreenToggle.isOn;
			SetScreenResolution (activeScreenResIndex);
		}

		PlayerPrefs.SetInt ("fullscreen", ((isFullscreen) ? 1 : 0));
		//PlayerPrefs.Save ();
	}

	public void SetMasterVolume(float value) {

	}
}
