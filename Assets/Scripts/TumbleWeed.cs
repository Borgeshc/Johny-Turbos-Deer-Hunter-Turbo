using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumbleWeed : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.unscaledDeltaTime);
    }
}
