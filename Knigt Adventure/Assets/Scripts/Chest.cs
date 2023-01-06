using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chest : MonoBehaviour
{
    Animator animator;

    IEnumerator Winner() {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("WinScene");
    }


    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("touch", false);
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            SFXManager.Instance.Playsfx("OpenChest");
            animator.SetBool("touch", true);
            StartCoroutine(Winner());
        }
    }
}
