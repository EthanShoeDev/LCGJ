using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallHealthBar : MonoBehaviour
{
    public float Health
    {
        get { return _health; }
        set
        {
            _health = value;
            if (_health < 0)
                _health = 0;
            if (_health > 100)
                _health = 100;
            UpdateBar();
        }
    }

    private float _health = 100;
    private SpriteRenderer foreground;
    private SpriteRenderer bckground;
    private float maxWidth;
    private bool startRun = false;

    void OnEnable()
    {
        if(!startRun)
            return;
        Health = 100;
    }

    // Use this for initialization
    void Start()
    {
        //Could possibly return wrong renderer
        foreground = transform.GetChild(0).GetComponent<SpriteRenderer>();
        bckground = GetComponent<SpriteRenderer>();
        if(foreground.gameObject.name != "Foreground")
            throw new NotSupportedException();
        maxWidth = foreground.size.x;
        UpdateBar();
        startRun = true;
    }

    void UpdateBar()
    {
        if (Health == 100)
        {
            Color bckColor = bckground.color;
            Color forColor = foreground.color;
            bckColor.a = 0;
            forColor.a = 0;
            bckground.color = bckColor;
            foreground.color = forColor;
        }
        else if (bckground.color.a == 0 || foreground.color.a == 0)
        {
            Color bckColor = bckground.color;
            Color forColor = foreground.color;
            bckColor.a = 1;
            forColor.a = 1;
            bckground.color = bckColor;
            foreground.color = forColor;
        }
        float percent = Health / 100;
        Vector2 size = foreground.size;
        size.x = maxWidth * percent;
        Vector2 pos = foreground.transform.localPosition;
        pos.x -= (foreground.size.x - size.x) / 2;
        foreground.transform.localPosition = pos;
        foreground.size = size;
    }
}
