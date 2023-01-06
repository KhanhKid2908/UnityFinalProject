using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WInScene : MonoBehaviour
{
    [SerializeField] Button replaybtn, mainMenubtn;
    public static WInScene Instance;

    private void Awake() 
    {
        MusicManager.Instance.PlayMusic("Victory");
        replaybtn.onClick.AddListener(OnClickReplay);
        mainMenubtn.onClick.AddListener(OnClickMainMenu);

        if(!Instance) //if (Instance == null)
        {
            Instance = this;
        }
    }

    public void OnClickReplay()
    {
        SceneManager.LoadScene("GameplayScene");
        MusicManager.Instance.PlayMusic("Scene1");
    }

    public void OnClickMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
        MusicManager.Instance.PlayMusic("MainMenu");
    }
}
