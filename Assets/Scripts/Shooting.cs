using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject gunBarrel;
    public GameObject bullet;
    public GameObject muzzleFlash;
    public AudioClip gunShotSound;
    public AudioClip reloadSound;

    AudioSource source;

    public float reloadTime;
    bool reloading;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(!reloading)
            {
                reloading = true;
                StartCoroutine(MuzzleFlash());
                Fire();
            }
        }
    }
    
    void Fire()
    {
        source.PlayOneShot(gunShotSound);
        Instantiate(bullet, gunBarrel.transform.position, gunBarrel.transform.rotation);
        StartCoroutine(Reload());
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(.2f);
        source.PlayOneShot(reloadSound);
        yield return new WaitForSeconds(reloadTime);
        reloading = false;
    }

    IEnumerator MuzzleFlash()
    {
        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(.25f);
        muzzleFlash.SetActive(false);
    }
}
