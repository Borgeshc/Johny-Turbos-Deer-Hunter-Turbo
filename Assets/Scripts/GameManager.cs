using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public Text buckText;
    public Text doeText;
    public Text fawnText;

    public static List<GameObject> ActiveObjects = new List<GameObject>(); 

    int bucksKilled;
    int doeKilled;
    int fawnKilled;

    SpawnManager spawnManager;

    private void Start()
    {
        spawnManager = GetComponent<SpawnManager>();
    }

	public void DeerKilled(string type)
    {
        Time.timeScale += .05f;
        switch(type)
        {
            case "Buck":
                bucksKilled++;
                spawnManager.GainTime();
                buckText.text = bucksKilled.ToString();
                break;
            case "Doe":
                doeKilled++;
                spawnManager.GainTime();
                doeText.text = doeKilled.ToString();
                break;
            case "Fawn":
                fawnKilled++;
                spawnManager.LoseTime();
                fawnText.text = fawnKilled.ToString();
                break;
        }
    }

    public void GameEnded()
    {
        buckText.text = bucksKilled + " Bucks Killed";
        doeText.text = doeKilled + " Does Killed";
        fawnText.text = fawnKilled + " Fawns Killed";
    }
}
