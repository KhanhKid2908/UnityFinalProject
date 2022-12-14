using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public int healthRestore = 20;
    public Vector3 spinRotationSpeed = new Vector3(0,180,0);

    AudioSource pickupSource;

    IEnumerator PlayHealSFX() {
        yield return new WaitForSeconds(0);

        SFXManager.Instance.Playsfx("Heal");
    }

    private void Awake() 
    {
        pickupSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        Damageable damageable = collision.GetComponent<Damageable>();

        if(damageable && damageable.Health < damageable.MaxHealth)
        {
            bool wasHealed = damageable.Heal(healthRestore);
            
            if(wasHealed)
            {
                if(pickupSource)
                    StartCoroutine(PlayHealSFX());

                Destroy(gameObject);
            }   
        }
    }

    private void Update() 
    {
        transform.eulerAngles += spinRotationSpeed * Time.deltaTime;
    }
}
