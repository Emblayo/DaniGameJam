using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateAudio : MonoBehaviour
{
    AudioSource audio;

    public AudioClip[] listClips;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        audio.clip = clip;
        audio.Play();
    }

    public void PlaySoundRandom()
    {
        int rng = Random.Range(0, listClips.Length);
        audio.clip = listClips[rng];
        audio.Play();
    }

}
