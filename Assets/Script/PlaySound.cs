using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{

    AudioSource _audioSource;

    private AudioSource AudioSource
    {
        get
        {
            if (!_audioSource) this._audioSource = this.GetComponent<AudioSource>();
            return _audioSource;
        }
    }
    public void Play()
    {
        AudioSource.Play();
    }
}
