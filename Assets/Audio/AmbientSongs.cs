using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to play ambient song list
public class AmbientSongs : MonoBehaviour
{
    public AudioClip[] trackList;
    private new AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        if (! audio.playOnAwake )
        {
            audio.clip = trackList[Random.Range(0, trackList.Length)];
            audio.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!audio.isPlaying)
        {
            audio.clip = trackList[Random.Range(0, trackList.Length)];
            audio.Play();
        }
    }
}
