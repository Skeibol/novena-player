using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider slider;

    public void ChangeAudioTime(float value)
    {
        audioSource.time = (audioSource.clip.length * value)/2;
    }

    public void Update()
    {
        
        slider.value = (audioSource.time / audioSource.clip.length) * 2;
    }


}
