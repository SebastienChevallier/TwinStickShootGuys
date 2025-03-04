using UnityEngine;
using BaseTemplate.Behaviours;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;
using System.Collections;
using UnityEngine.Audio;

public class SoundManager : MonoSingleton<SoundManager>
{
    public List<AudioStruct> sounds = new List<AudioStruct>();

    private void Start()
    {
        ApplySavedVolumes();

        AudioStruct sound = sounds[0];
        sound.source = transform.GetChild(0).GetComponent<AudioSource>();

        sound = sounds[1];
        sound.source = transform.GetChild(1).GetComponent<AudioSource>();

        sound = sounds[2];
        sound.source = transform.GetChild(2).GetComponent<AudioSource>();

        StartCoroutine(PlayMusic(sounds[0]));
        StartCoroutine(PlayMusic(sounds[1]));
    }


    public AudioStruct GetAudioClip(AudioSound sound)
    {
        foreach (AudioStruct soundObj in sounds)
        {
            if(soundObj.Type == sound)
            {                
                return soundObj;
            }
        }

        return new AudioStruct();
    }

    public void PlayAudio(AudioSound sound)
    {
        AudioStruct audio = GetAudioClip(sound);
        int indice = UnityEngine.Random.Range(0, audio.clips.Count);
        audio.source.clip = audio.clips[indice];
        audio.source.Play();
    }

    public void PlayAudio(AudioSound sound, Vector3 position)
    {
        AudioStruct audio = GetAudioClip(sound);
        int indice = UnityEngine.Random.Range(0, audio.clips.Count);
        audio.source.clip = audio.clips[indice];
        audio.source.transform.position = position;
        audio.source.Play();        
    }

    public void ApplySavedVolumes()
    {
        float masterVolume = PlayerPrefs.GetFloat("Master", 1f);
        float musicVolume = PlayerPrefs.GetFloat("Music", 1f);
        float sfxVolume = PlayerPrefs.GetFloat("SFX", 1f);

        foreach (AudioStruct sound in sounds)
        {
            if (sound.Type == AudioSound.Music)
                sound.source.volume = musicVolume * masterVolume;
            else
                sound.source.volume = sfxVolume * masterVolume;
        }

        AudioListener.volume = masterVolume;
    }

    public IEnumerator PlayMusic(AudioStruct audio)
    {   
        int indice = UnityEngine.Random.Range(0, audio.clips.Count);

        audio.source.clip = (audio.clips[indice]);
        audio.source.Play();
        float secondes = audio.clips[indice].length / 1.25f;
        yield return new WaitForSeconds(secondes);

        StartCoroutine(PlayMusic(audio));
    }
}

[Serializable]
public struct AudioStruct
{
    public AudioSound Type;
    public List<AudioClip> clips;
    public AudioSource source;
}

public enum AudioSound
{
    Step,
    Shoot,
    Hit,
    Environement,
    Music
}
