using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public float delayLoadNextLevel;

	void Start () {

        Invoke("LoadNextLevel", delayLoadNextLevel);
    }

    public void LoadLevel(string name) {
		Debug.Log ("New Level load: " + name);
		SceneManager.LoadScene(name);
	}

	public void QuitRequest() {
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

	public void LoadNextLevel() {
        int index = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(index);
	}

}