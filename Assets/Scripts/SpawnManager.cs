using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> deers;
    public List<GameObject> spawnpoints;
    public List<Animator> anims;
    public GameObject tumbleWeed;
    public GameObject menuButton;

    public float timer;
    [Tooltip("New wave will spawn every (spawnTime) seconds.")]
    public float spawnTime;
    public Text timerText;

    public GameObject gameOverPanel;
    GameManager gameManager;

    bool spawning;
    bool gameover;
    bool endingGame;

    bool spawningTubleWeed;

    private void Start()
    {
        Time.timeScale = 1;
        gameManager = GetComponent<GameManager>();
    }
	
	void Update ()
    {
        if(!gameover)
        {
            timer -= Time.unscaledDeltaTime;
            timerText.text = (int)timer + "";
        }
        if((int)timer % spawnTime == 0 && !spawning)
        {
            spawning = true;
            int randomDeer = Random.Range(0, deers.Count);
            int randomSpawn = Random.Range(0, spawnpoints.Count);
            Instantiate(deers[randomDeer], spawnpoints[randomSpawn].transform.position, Quaternion.identity);
            StartCoroutine(SpawnWaitTime());

            if(Application.loadedLevel == 2 && (int)timer % (spawnTime * 2) == 0 && (int)timer != 0 && !spawningTubleWeed)
            {
                spawningTubleWeed = true;
                int randomTumbleSpawn = Random.Range(0, spawnpoints.Count);
                Instantiate(tumbleWeed, spawnpoints[randomTumbleSpawn].transform.position, Quaternion.identity);
                StartCoroutine(TumbleWeedWaitTime());
            }
        }

        if(timer <= 0)
        {
            foreach(Animator anim in anims)
            {
                anim.SetTrigger("EndGame");
            }

            gameover = true;
            timer = 0;
            timerText.text = (int)timer + "";

            if(!endingGame)
            {
                endingGame = true;
                StartCoroutine(StopGame());
            }
        }
    }

    public void GainTime()
    {
        timer += 5;
    }

    public void GainTime(float time)
    {
        timer += time;
    }

    public void LoseTime()
    {
        timer -= 5;
    }

    IEnumerator SpawnWaitTime()
    {
        yield return new WaitForSeconds(1);
        spawning = false;
    }

    IEnumerator TumbleWeedWaitTime()
    {
        yield return new WaitForSeconds(1);
        spawningTubleWeed = false;
    }

    IEnumerator StopGame()
    {
        foreach (GameObject go in GameManager.ActiveObjects)
        {
            if(go != null)
            go.SetActive(false);
        }
        GameObject.Find("Timer").SetActive(false);
        GameObject.Find("Player").SetActive(false);
        gameManager.GameEnded();
        yield return new WaitForSeconds(3);
    
        menuButton.SetActive(true);

        Time.timeScale = 0;
    }
}
