using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> deers;
    public List<GameObject> spawnpoints;
    public float timer;
    [Tooltip("New wave will spawn every (spawnTime) seconds.")]
    public float spawnTime;
    public Text timerText;

    bool spawning;
	
	void Update ()
    {
        timer -= Time.unscaledDeltaTime;
        timerText.text = (int)timer + "";
        if((int)timer % spawnTime == 0 && !spawning)
        {
            spawning = true;
            int randomDeer = Random.Range(0, deers.Count);
            int randomSpawn = Random.Range(0, spawnpoints.Count);
            Instantiate(deers[randomDeer], spawnpoints[randomSpawn].transform.position, Quaternion.identity);
            StartCoroutine(SpawnWaitTime());
        }

        if(timer <= 0)
        {
            //Load the end scene
        }
    }

    public void GainTime()
    {
        timer += 3;
    }

    public void LoseTime()
    {
        timer -= 3;
    }

    IEnumerator SpawnWaitTime()
    {
        yield return new WaitForSeconds(1);
        spawning = false;
    }
}
