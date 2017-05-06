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
    int ammo = 6;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
        {
            if(!reloading)
            {
                reloading = true;

                if (Application.loadedLevel == 2 && ammo > 0)
                {
                    StartCoroutine(RevolverMuzzleFlash());
                    FireRevolver();
                }

                else
                {
                    Fire();
                    StartCoroutine(MuzzleFlash());
                }
            }
        }
    }

    void FireRevolver()
    {
        ammo--;

        source.PlayOneShot(gunShotSound);
        Instantiate(bullet, gunBarrel.transform.position, gunBarrel.transform.rotation);

        if(ammo <= 0)
            StartCoroutine(Reload());

        reloading = false;
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
        ammo = 6;
        reloading = false;
    }

    IEnumerator MuzzleFlash()
    {
        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(.25f);
        muzzleFlash.SetActive(false);
    }


    IEnumerator RevolverMuzzleFlash()
    {
        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(.05f);
        muzzleFlash.SetActive(false);
    }
}
