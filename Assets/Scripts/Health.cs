using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;

    public enum DeerType
    {
        Buck,
        Doe,
        Fawn
    };

    public DeerType deerType = DeerType.Buck;
    
    GameManager gameManager;
    float health;
    
	void Start ()
    {
        health = maxHealth;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

    public void TookDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Died();
        }
    }

    void Died()
    {
        gameManager.DeerKilled(deerType.ToString());
        Destroy(gameObject);
    }
}
