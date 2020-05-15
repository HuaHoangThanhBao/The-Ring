using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour {

    public static AudioClip background, error;
    static AudioSource source;

    private void Start()
    {
        background = Resources.Load<AudioClip>("Background");
        error = Resources.Load<AudioClip>("Error");
        source = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "Error":
                source.Stop();
                source.PlayOneShot(error);
                break;
         }
    }
}
