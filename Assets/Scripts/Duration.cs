using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Duration : MonoBehaviour
{
    public AudioSource _audio;
    private int totalSeconds;
    private float seconds;
    private float minutes;


    void Update()
    {
        totalSeconds = (int)Mathf.Floor(_audio.time);
        int seconds = totalSeconds % 60;
        int minutes = totalSeconds / 60;
        string time = (minutes / 10 == 0 ? "0" : "") + minutes + ":" + (seconds / 10 == 0 ? "0" : "") + seconds;

        this.GetComponent<TMP_Text>().text = time;

    }
}
