using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text buckText;
    public Text doeText;
    public Text fawnText;

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
}
