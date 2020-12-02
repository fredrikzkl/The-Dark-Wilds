using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    
    public static AudioManager instance;
    
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }
    }

    void Update()
    {

    }

    public void FadeIn(string name, float time, float volume)
    {

    }

    public void FadeOut(string name)
    {

    }

    
    

    public void Play(string name)
    {
        GetSound(name).source.Play();
    }

    public void Stop(string name)
    {
        GetSound(name).source.Stop();
    }


    public Sound GetSound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound: " + name + " was not found (Play)");
        }
        return s;
    }

}
