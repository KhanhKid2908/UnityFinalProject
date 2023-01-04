using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button playbtn, settingbtn;
    [SerializeField] GameObject settingPanel, mainMenuPanel;
    public static MainMenu Instance;

    private void Awake() 
    {
        playbtn.onClick.AddListener(OnClickPlay);
        settingbtn.onClick.AddListener(OnClickSetting);

        mainMenuPanel.SetActive(true);

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
}
