using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public Text enemy1Text;
    public Text enemy2Text;
    public Text friendlyText;

    public static List<GameObject> ActiveObjects = new List<GameObject>(); 

    public static bool isSinglePlayer;

    int enemy1Killed;
    int enemy2Killed;
    int friendlyKilled;

    SpawnManager spawnManager;

    private void Start()
    {
        if(isSinglePlayer)
        spawnManager = GetComponent<SpawnManager>();
    }

	public void DeerKilled(string type)
    {
        Time.timeScale += .05f;
        switch(type)
        {
            case "Enemy1":
                enemy1Killed++;
                spawnManager.GainTime();
                enemy1Text.text = enemy1Killed.ToString();
                break;
            case "Enemy2":
                enemy2Killed++;
                spawnManager.GainTime();
                enemy2Text.text = enemy2Killed.ToString();
                break;
            case "Friendly":
                friendlyKilled++;
                spawnManager.LoseTime();
                friendlyText.text = friendlyKilled.ToString();
                break;
        }
    }

    public void GameEnded()
    {
        switch(Application.loadedLevel)
        {
            case 1: //Johny Turbo's Deer Hunter Turbo
                enemy1Text.text = enemy1Killed + " Bucks Killed";
                enemy2Text.text = enemy2Killed + " Does Killed";
                friendlyText.text = friendlyKilled + " Fawns Killed";
                break;

            case 2: //Johny Turbo's Bandit Hunter Turbo
                enemy1Text.text = enemy1Killed + " Bandits Killed";
                enemy2Text.text = enemy2Killed + " Thugs Killed";
                friendlyText.text = friendlyKilled + " Banker Killed";
                break;
        }
    }
}
