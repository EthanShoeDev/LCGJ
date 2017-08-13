using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseManager : MonoBehaviour {

    public GameObject panel = null;

    private bool PauseState = false;

    void Awake()
    {
        panel = GameObject.FindWithTag("PauseMenu");

        if (panel == null)
            Debug.LogError("Pause Menu not found at Hierarchy, as GUI child.");
        else
            panel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Pause();
        }

        if (PauseState)
            panel.SetActive(true);
        else
            panel.SetActive(false);
    }

    public void Pause() {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        PauseState = !PauseState;
    }

    public void Quit() {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}