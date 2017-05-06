using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public float minFireFreq;
    public float maxFireFreq;
    public GameObject barrel;
    public GameObject bullet;

    bool firing;
	
	void Update ()
    {
		if(!firing)
        {
            firing = true;
            StartCoroutine(Fire());
        }
	}

    IEnumerator Fire()
    {
        float fireFreq = Random.Range(minFireFreq, maxFireFreq);
        Instantiate(bullet, barrel.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(fireFreq);
        firing = false;
    }
}
