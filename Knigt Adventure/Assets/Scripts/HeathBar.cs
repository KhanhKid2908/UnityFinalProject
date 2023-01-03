using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeathBar : MonoBehaviour
{
    public Slider healthSlider;
    public TMP_Text healthbarText;

    Damageable playerDamageable;

    private void Awake() 
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        
        if(player == null)
        {
            Debug.Log("No player found in the scence. Make sure it has tag 'Player'");
        }
        
        playerDamageable = player.GetComponent<Damageable>();
    }

    // Start is called before the first frame update
    void Start()
    {
        healthSlider.value = CalcualateSliderPercentage(playerDamageable.Health, playerDamageable.MaxHealth);
        healthbarText.text = "HP " + playerDamageable.Health + " / " + playerDamageable.MaxHealth;
    }

    private void OnEnable() 
    {
        playerDamageable.healthChanged.AddListener(OnPlayerHealthChanged);
    }

    private void OnDisable() 
    {
        playerDamageable.healthChanged.RemoveListener(OnPlayerHealthChanged);
    }

    private float CalcualateSliderPercentage(float currentHealth, float maxHealth)
    {
        return currentHealth / maxHealth;
    }

    private void OnPlayerHealthChanged(int newHealth, int maxHealth)
    {
        healthSlider.value = CalcualateSliderPercentage(newHealth, maxHealth);
        healthbarText.text = "HP " + newHealth + " / " + maxHealth;
    }
}
