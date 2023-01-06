using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public Transform launchPoint;
    public GameObject projectilePrefab;

    IEnumerator PlayFireSFX() {
        yield return new WaitForSeconds(1/2);

        SFXManager.Instance.Playsfx("Fire");
    }
    
    public void FireProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, launchPoint.position, projectilePrefab.transform.rotation);
        StartCoroutine(PlayFireSFX());
        Vector3 origScale = projectile.transform.localScale;
        
        projectile.transform.localScale = new Vector3(
            origScale.x * transform.localScale.x > 0 ? 1 : -1,
            origScale.y * transform.localScale.x > 0 ? 1 : -1,
            origScale.z 
        );
    }
}
