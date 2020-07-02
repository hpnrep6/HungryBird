using UnityEngine.Audio;
using System;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    public AudioClass[] audioClips;
    public static AudioManager instance;
    void Awake()
    {
        if(instance == null) {
            instance = this;
            for(int i = 0; i < audioClips.Length; i++) {
                audioClips[i].audioSource = gameObject.AddComponent<AudioSource>();
                AudioSource source = audioClips[i].audioSource;
                source.clip = audioClips[i].clip;
                source.volume = audioClips[i].volume;
                source.pitch = audioClips[i].pitch;
                source.loop = audioClips[i].loop;
            }
            Play("background"); // starts background music
        } else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    public void Play(string name) {
        AudioClass audio = Array.Find(audioClips,audioClass => audioClass.name == name);
        if(audio != null) {
            audio.audioSource.Play();
        }    
    }

    public void Play(string name, float pitch) {
        AudioClass audio = Array.Find(audioClips,audioClass => audioClass.name == name);
        if(audio != null) {
            audio.audioSource.pitch = pitch;
            audio.audioSource.Play();
        }    
    }
}
