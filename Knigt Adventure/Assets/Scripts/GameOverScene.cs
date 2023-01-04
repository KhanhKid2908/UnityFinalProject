using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    [SerializeField] Button replaybtn, mainMenubtn;
    public static GameOverScene Instance;

    private void Awake() 
    {
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
    }

    public void OnClickMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
