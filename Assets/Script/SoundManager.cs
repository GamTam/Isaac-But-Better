using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : Singleton<SoundManager>
{
    private List<AudioSource> _loadedSFX = new List<AudioSource>();
    
    public void Stop(AudioSource s) {
        s.Stop();
    }

    public void Play(string name)
    {
        Play(name, 1);
    }

    public AudioSource Play(string name, float pitch = 1f)
    {
        name = name.Trim();
        bool useLocal = false;
        bool containsKey = false;

        AudioSource s = _loadedSFX.Find(x => x.clip.name == name);

        if (s == null)
        {
            AudioClip clip = Resources.Load<AudioClip>("SFX/" + name);
            if (clip != null)
            {
                s = gameObject.AddComponent<AudioSource>();
                s.clip = clip;
                s.loop = false;
                _loadedSFX.Add(s);
            }
        }
    
        if (s == null)
        {
            Debug.LogError($"Failed to load sound \"{name}\"");
            return null;
        }

        s.PlayOneShot(s.clip);
        return s;
    }
}
