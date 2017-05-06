using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float damage;
    SpawnManager spawnManager;

    private void Start()
    {
        spawnManager = GameObject.Find("GameManager").GetComponent<SpawnManager>();
    }

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy" && transform.tag != "Bullet")
        {
            print("1");
            other.GetComponent<Health>().TookDamage(damage);
            Destroy(this.gameObject);
        }
        else if (other.tag == "Player" && transform.tag == "Bullet")
        {
            print("2");
            spawnManager.LoseTime();
            Destroy(gameObject);
        }
        else if(other.tag == "Bounds")
        {
            print("3");
            Destroy(gameObject);
        }
    }
}