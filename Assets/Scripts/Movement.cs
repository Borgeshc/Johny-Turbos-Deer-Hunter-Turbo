using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float minClamp;
    public float maxClamp;
    public bool keyboardTurn;

    float vertical;

    Quaternion rightRotation = new Quaternion(0,180,0,0);

    private void Update()
    {
        vertical = Input.GetAxis("Vertical");

        if(keyboardTurn)
        {
            if (Input.GetKeyDown(KeyCode.A) && transform.rotation != Quaternion.identity)
            {
                transform.rotation = Quaternion.identity;
            }
            else if (Input.GetKeyDown(KeyCode.D) && transform.rotation != rightRotation)
            {
                transform.rotation = rightRotation;
            }
        }
        else
        {
            if(Input.mousePosition.x < Screen.width / 2 && transform.rotation != Quaternion.identity)
            {
                transform.rotation = Quaternion.identity;
            }
            else if (Input.mousePosition.x > Screen.width / 2 && transform.rotation != rightRotation)
            {
                transform.rotation = rightRotation;
            }
        }
        
        transform.Translate(new Vector3(0, vertical * speed * Time.deltaTime, 0));
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, minClamp, maxClamp), transform.position.z);
    }
}
