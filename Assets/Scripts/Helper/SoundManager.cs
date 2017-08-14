using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour {

	// Control audio source clips
	public AudioSource musicSource;
	public AudioSource sfxSource;

	// singleton controller
	private static SoundManager instance = null;

    // public int[] musicPerLevel
	public AudioClip[] levelMusicSet;
    private static AudioClip currentPlaying = null;

    public Slider musicSlider;
    public Slider sfxSlider;
    public float currentMusicValue;
    public float currentSfxValue;
    private static bool musicOn = true;
    private static bool sfxOn   = true;

    public int[] levelTrack;

	// Use this for initialization
	void Awake () {

		// Check sound manager instance existence
		if (instance == null) {
			instance = this;	// create instance if not exists
		} else if (instance != this) {
			Destroy (gameObject);	// destroy if it tries to create other and force singleton
		}

		DontDestroyOnLoad (gameObject);
		SceneManager.sceneLoaded += LoadLevelMusic;

        musicSlider.value = .5f;
        sfxSlider.value = .5f;
        musicSource.volume = musicSlider.value;
        sfxSource.volume = sfxSlider.value;
	}

    void Update () {
        musicSource.volume = musicSlider.value;
        currentMusicValue = 
        sfxSource.volume = sfxSlider.value;

        if (musicSlider.value == 0 && sfxSlider.value == 0)
        {
            musicSlider.value = currentMusicValue;
            sfxSlider.value = currentSfxValue;
        }
        else
        {
            
        }
    }

	// disable method when scene unload
	void OnDisable () {
		SceneManager.sceneLoaded -= LoadLevelMusic;
	}

	// Audio controller (scene and mode params are mandatory)
	void LoadLevelMusic (Scene scene, LoadSceneMode mode) {

        // get current scene number
        int sceneNumber = scene.buildIndex;

        // set the AudioSource to a private var
        musicSource = this.GetComponent<AudioSource>();

        int track = levelTrack[sceneNumber];
		AudioClip music = levelMusicSet[track];

        musicSource.loop = true;

        // check if music exists and its on
        if (musicOn) {
            if (!music) {
                // Debug.LogError("Level music not found!");
                musicSource.Stop();
            }
            else {
                if (currentPlaying == null || currentPlaying != music) {
                    currentPlaying = music;
                    musicSource.clip = music;
                    musicSource.volume = musicSlider.value;
                    musicSource.Play();
                }
            }
        }
	}

    public void PlaySingle(AudioClip clip) {
        // only play music if it's enabled
        if (sfxOn) {
            sfxSource.clip = clip;
            sfxSource.Play();
        }
    }

    public void ToggleMusic () {
        Debug.Log("click music");
		musicOn = !musicOn;

        if (musicOn)
            instance.GetComponent<SoundManager>().musicSource.Play();
        else
            instance.GetComponent<SoundManager>().musicSource.Stop();
    }

	public void ToggleSFX () {
        Debug.Log("click sfx");
        sfxOn = !sfxOn;
    }
}