using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{

    private Text textUI;

    private float timeLeft
    {
        get { return GameController.Instance.TimeLeft; }
        set { GameController.Instance.TimeLeft = value; }
    }
    private GameObject Player;

	// Use this for initialization
	void Start ()
	{
	    textUI = GetComponent<Text>();
        Player = GameObject.Find("Player");
        SceneManager.activeSceneChanged += SceneManagerOnActiveSceneChanged;
	}

    private void SceneManagerOnActiveSceneChanged(Scene arg0, Scene scene)
    {
        timeLeft = 30f;
    }

    // Update is called once per frame
	void Update ()
	{
	    timeLeft -= Time.deltaTime;
	    if (timeLeft < 0)
	        timeLeft = 0;
	    textUI.text = timeLeft.ToString("0.0");
	}
}
