using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumbleWeed : MonoBehaviour
{
    public float speed;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        if (GameObject.Find("Player").transform.position.x > transform.position.x)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
            anim.SetTrigger("Right");
        }
        else
        {
            anim.SetTrigger("Left");
        }
    }

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.unscaledDeltaTime);
    }
}
