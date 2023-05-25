using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager2 : MonoBehaviour
{
    public Sound1[] sounds;
    void Start()
    {
        foreach(Sound1 s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
        }

        PlaySound("MainTheme");
    }

   public void PlaySound(string name)
    {
        foreach (Sound1 s in sounds)
        {
            if (s.name == name)
                s.source.Play();
        }
    }
}
