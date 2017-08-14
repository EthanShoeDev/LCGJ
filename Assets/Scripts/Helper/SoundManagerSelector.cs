using UnityEngine;
using UnityEngine.UI;

public class SoundManagerSelector : MonoBehaviour {

    public SoundManager sMan;

    public Slider sfx;
    public Slider bmg;

    void Awake()
    {
        sMan = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        bmg.value = .5f;
        sfx.value = .5f;

        sMan.musicSlider = bmg;
        sMan.sfxSlider = sfx;
    }
}
