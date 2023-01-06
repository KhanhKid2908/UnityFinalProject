using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Award : MonoBehaviour
{
    public GameObject[] reward;
    // Update is called once per frame
    void Update()
    {
        reward = GameObject.FindGameObjectsWithTag("Finish");
        if(reward.Length == 0)
        {
            Destroy(gameObject);
        }
    }
}
