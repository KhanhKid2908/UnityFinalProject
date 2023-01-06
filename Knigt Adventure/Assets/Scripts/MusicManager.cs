using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
    public class AudioConfig
    {
        public string m_name;
        public AudioClip m_clip;
    }

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    [SerializeField] AudioSource music, sound;
    [SerializeField] List<AudioConfig> audioConfig;

    private void Awake() {
        if(Instance==null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(this);
    }

    public void PlayMusic(string musicName)
    {
        for(int i = 0; i < audioConfig.Count; i++)
        {
            if(audioConfig[i].m_name == musicName)
            {
                music.clip = audioConfig[i].m_clip;
                music.Play();
                break;
            }
        }
    }

    public bool getMusicTgl()
    {
        if(music.volume == 0)
        {
            return false;
        }
        else
        {
            return true;

        }
    }

    public void MusicChanged(bool isOn)
    {
        if (isOn)
        {
            Debug.Log("On");
            music.volume = 1;
        } else {
            Debug.Log("Off");
            music.volume = 0;
        }
    }
}
