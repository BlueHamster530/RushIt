using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicInfo : MonoBehaviour
{
    AudioSource audio;

    [SerializeField]
    AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent <AudioSource> ();
        audio.clip = clip;
    }

    public void MusicStartOrPause(bool _Value)
    {
        if (audio.clip == null) return;

        if (_Value == false)
            audio.Pause();
        else
            audio.Play();
    }
}
