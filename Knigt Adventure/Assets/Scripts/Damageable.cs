using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    public UnityEvent<int, Vector2> damgeableHit;
    public UnityEvent damgeableDeath;
    public UnityEvent<int, int> healthChanged;
    int count = 0;

    Animator animator;

    IEnumerator PlayDeadSFX() {
        yield return new WaitForSeconds(0);

        SFXManager.Instance.Playsfx("Dead");
    }

    public int _maxHealth = 100;

    public int MaxHealth 
    {
        get
        {
            return _maxHealth;
        } set
        {
            _maxHealth = value;
        }
    }

    [SerializeField]
    private int _health = 100;

    public int Health 
    {
        get
        {
            return _health;
        } set
        {
            _health = value;
            healthChanged?.Invoke(_health, MaxHealth);

            // If health drops below 0, character is no longer alive
            if(_health <= 0)
            {
                IsAlive = false;
            }
        }
    }

    [SerializeField]
    private bool _isAlive = true;

    [SerializeField]
    private bool isInvisible = false;

    private float timeSinceHit = 0;
    public float invisibilityTime = 1f;

    public bool IsAlive 
    {
        get
        {
            return _isAlive;
        } set
        {
            _isAlive = value;
            animator.SetBool(AnimationStrings.isAlive, value);
            Debug.Log("IsAlive set " + value);

            if(value == false)
            {
                damgeableDeath.Invoke();
            }
        }
    }

    // The velocity should not be chagned while this is true but needs to be respected by other physics components like
    // the player controller
    public bool LockVelocity{ get
        {
            return animator.GetBool(AnimationStrings.lockVelocity);
        } 
        set 
        {
            animator.SetBool(AnimationStrings.lockVelocity, value);
        }
    }

    private void Awake() 
    {
        animator = GetComponent<Animator>();
        
    }

    private void Update() 
    {
        if(isInvisible)
        {
            if(timeSinceHit > invisibilityTime)
            {
                // Remove invisibility
                isInvisible = false;
                timeSinceHit = 0;
            }

            timeSinceHit += Time.deltaTime;
        }

        if(!IsAlive)
        {
            count++;
            if(count == 1)
                StartCoroutine(PlayDeadSFX());
        }

    }

    // Returns whter the damgeable took damge or not
    public bool Hit(int damage, Vector2 knockback)
    {
        if(IsAlive && !isInvisible)
        {
            Health -= damage;
            isInvisible = true;

            // Notify other subscribed components that the damageable was hit to handle the knockback and such
            animator.SetTrigger(AnimationStrings.hitTrigger);
            LockVelocity = true;
            damgeableHit?.Invoke(damage, knockback);
            CharacterEvents.characterDamaged.Invoke(gameObject, damage);

            return true;
        }

        // Unable to be hit
        return false;
    }

    public bool Heal(int healthRestore)
    {
        if(IsAlive && Health < MaxHealth)
        {
            int maxHeal = Mathf.Max(MaxHealth - Health, 0);
            int actualHeal = Mathf.Min(maxHeal, healthRestore);
            Health += actualHeal;
            CharacterEvents.characterHealed(gameObject, actualHeal);
            return true;
        }

        return false;
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.tag.Equals("DeadGround"))
        {
            IsAlive = false;
        }
    }
}
