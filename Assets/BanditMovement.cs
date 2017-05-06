using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditMovement : MonoBehaviour
{
    public float speed;
    public float minMoveTime;
    public float maxMoveTime;

    float moveTime;
    float timer;
    Health health;

    void Start()
    {
        if (GameObject.Find("Player").transform.position.x > transform.position.x)
            transform.rotation = new Quaternion(0, 180, 0, 0);

        moveTime = Random.Range(minMoveTime, maxMoveTime);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer < moveTime)
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
