using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
    public class SoundConfig
    {
        public string m_name;
        public AudioClip m_clip;
    }

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;

    [SerializeField] AudioSource sfx, sound;
    [SerializeField] List<SoundConfig> soundConfig;

    private void Awake() {
        if(Instance==null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(this);
    }

    public void Playsfx(string sfxName)
    {
        for(int i = 0; i < soundConfig.Count; i++)
        {
            if(soundConfig[i].m_name == sfxName)
            {
                sfx.clip = soundConfig[i].m_clip;
                sfx.Play();
                break;
            }
        }
    }

    public bool getsfxTgl()
    {
        if(sfx.volume == 0)
        {
            return false;
        }
        else
        {
            return true;

        }
    }

    public void sfxChanged(bool isOn)
    {
        if (isOn)
        {
            Debug.Log("On");
            sfx.volume = 1;
        } else {
            Debug.Log("Off");
            sfx.volume = 0;
        }
    }
}
