using UnityEngine;
using UnityEngine.UI;

public class BMG_Selector : MonoBehaviour {

    public Text songNumber;
    public SoundManager soundMan;

    private int track = 0;

    void Awake()
    {
        songNumber.text = track.ToString();
    }

    void Update()
    {
        
    }

    public void NextTrack() {
        track++;
        SwapTrack();
    }

    public void PreviousTrack() {
        track--;
        SwapTrack();
    }

    void SwapTrack ()
    {
        if (track < 0)
        {
            track = 0;
        }
        else if (track > soundMan.levelMusicSet.Length - 1)
        {
            track = soundMan.levelMusicSet.Length - 1;
        }
        else 
        {
            songNumber.text = track.ToString();
            soundMan.musicSource.Stop();
            soundMan.musicSource.clip = soundMan.levelMusicSet[track];
            soundMan.musicSource.Play();
        }
    }
}
