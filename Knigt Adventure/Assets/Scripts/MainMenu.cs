using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] MusicManager musicManagerpref;
    [SerializeField] SFXManager sfxManagerpref;
    [SerializeField] Button playbtn, settingbtn, backbtn;
    [SerializeField] Toggle soundTgl, musicTgl;
    [SerializeField] GameObject settingPanel, mainMenuPanel;
    public static MainMenu Instance;

    private void Awake() 
    {
        playbtn.onClick.AddListener(OnClickPlay);
        settingbtn.onClick.AddListener(OnClickSetting);
        backbtn.onClick.AddListener(OnClickBack);
        musicTgl.onValueChanged.AddListener(MusicToggle);
        soundTgl.onValueChanged.AddListener(SoundToggle);
        var musics = GameObject.FindGameObjectsWithTag("MusicManager");
        var sfx = GameObject.FindGameObjectsWithTag("SFXManager");

        if(sfx == null || sfx.Length == 0)
        {
            Instantiate(sfxManagerpref);
        }

        if(musics == null || musics.Length == 0)
        {
            Instantiate(musicManagerpref);
        }

        mainMenuPanel.SetActive(true);

        // bool isMusic = PlayerPrefs.GetInt("Music") == 1? true : false;

        if(!Instance) //if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start() 
    {
        if(MusicManager.Instance != null)
            musicTgl.SetIsOnWithoutNotify(MusicManager.Instance.getMusicTgl());
        if(SFXManager.Instance != null)
            soundTgl.SetIsOnWithoutNotify(SFXManager.Instance.getsfxTgl());
    }

    public void OnClickPlay()
    {
        SceneManager.LoadScene("GameplayScene");
        MusicManager.Instance.PlayMusic("Scene1");
    }

    public void OnClickSetting()
    {
        mainMenuPanel.SetActive(false);
        settingPanel.SetActive(true);
    }

    public void OnClickBack()
    {
        mainMenuPanel.SetActive(true);
        settingPanel.SetActive(false);
    }

    public void MusicToggle(bool isOn)
    {
        MusicManager.Instance.MusicChanged(isOn);
    }
    public void SoundToggle(bool isOn)
    {
        SFXManager.Instance.sfxChanged(isOn);
    }
}
