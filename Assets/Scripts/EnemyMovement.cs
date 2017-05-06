using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    SpawnManager spawnManager;
    Health health;

    void Start ()
    {
		if(GameObject.Find("Player").transform.position.x > transform.position.x)
            transform.rotation = new Quaternion(0, 180, 0, 0);

        spawnManager = GameObject.Find("GameManager").GetComponent<SpawnManager>();
        health = GetComponent<Health>();
	}
	
	void Update ()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Bounds")
        {
            GameManager.ActiveObjects.Remove(gameObject);
            if (health.deerType == Health.ObjectType.Friendly)
                spawnManager.GainTime();
            else
                spawnManager.LoseTime();
            Destroy(gameObject);
        }
    } 
}
