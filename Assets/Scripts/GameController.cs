using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //Put all info that needs carry over between scenes here (Lives, Health... etc)
    public float PlayerHealth;
    public float MaxHealth = 100;
    [HideInInspector] public float TimeLeft = 30f;

    public static GameController Instance;
    public List<string> Levels;
    public int CurrentLevelIndex;
    // Use this for initialization
	void Awake () {
	    if (Instance == null)
	        Instance = this;
	    else if (Instance != this)
	        Destroy(gameObject);
        DontDestroyOnLoad(this);
	    CurrentLevelIndex = Levels.IndexOf(SceneManager.GetActiveScene().name);
	    PlayerHealth = MaxHealth;
	}

	// Update is called once per frame
	void Update () {
		
	}

    public void LoadScene(int Index)
    {
        SceneManager.LoadScene(Levels[Index]);
        CurrentLevelIndex = Index;
    }

}
