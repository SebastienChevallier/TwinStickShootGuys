using UnityEngine;
using BaseTemplate.Behaviours;
using System.Collections.Generic;
using System;

public class SoundManager : MonoSingleton<SoundManager>
{
    public List<AudioStruct> sounds;
    private AudioSource source;

    private void Start()
    {
        source = transform.GetChild(0).GetComponent<AudioSource>();
    }

    public AudioClip GetAudioClip(AudioSound sound)
    {
        foreach (AudioStruct soundObj in sounds)
        {
            if(soundObj.Type == sound)
            {
                return soundObj.clip;
            }
        }

        return null;
    }

    public void PlayAudio(AudioSound sound)
    {
        source.clip = GetAudioClip(sound);
        source.Play();
    }

    public void PlayAudio(AudioSound sound, Vector3 position)
    {
        source.clip = GetAudioClip(sound);
        source.transform.position = position;
        source.Play();
    }
}

[Serializable]
public struct AudioStruct
{
    public AudioSound Type;
    public AudioClip clip;
}

public enum AudioSound
{
    Step,
    Shoot,
    Hit,
    Environement
}
