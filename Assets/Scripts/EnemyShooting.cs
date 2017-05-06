using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public float minFireFreq;
    public float maxFireFreq;
    public GameObject barrel;
    public GameObject bullet;
    public GameObject muzzleFlash;

    bool firing;
	
	void Update ()
    {
		if(!firing)
        {
            firing = true;
            StartCoroutine(MuzzleFlash());
            StartCoroutine(Fire());
        }
	}

    IEnumerator Fire()
    {
        float fireFreq = Random.Range(minFireFreq, maxFireFreq);
        GameObject clone = Instantiate(bullet, barrel.transform.position, transform.rotation) as GameObject;
        clone.GetComponent<Projectile>().tag = "Bullet";
        yield return new WaitForSeconds(fireFreq);
        firing = false;
    }

    IEnumerator MuzzleFlash()
    {
        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(.25f);
        muzzleFlash.SetActive(false);
    }
}
