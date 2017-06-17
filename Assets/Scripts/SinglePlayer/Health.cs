using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;

    public enum ObjectType
    {
        Enemy1,
        Enemy2,
        Friendly
    };

    public ObjectType deerType = ObjectType.Enemy1;
    
    GameManager gameManager;
    float health;
    
	void Start ()
    {
        health = maxHealth;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        GameManager.ActiveObjects.Add(gameObject);
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
        GameManager.ActiveObjects.Remove(gameObject);
        Destroy(gameObject);
    }
}
