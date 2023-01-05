using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
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

        mainMenuPanel.SetActive(true);

        bool isMusic = PlayerPrefs.GetInt("Music") == 1? true : false;

        if(!Instance) //if (Instance == null)
        {
            Instance = this;
        }
    }

    public void OnClickPlay()
    {
        SceneManager.LoadScene("GameplayScene");
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
        if (isOn)
        {
            Debug.Log("On");
            AudioListener.volume = 1;
        } else {
            Debug.Log("Off");
            AudioListener.volume = 0;
        }
    }
}
