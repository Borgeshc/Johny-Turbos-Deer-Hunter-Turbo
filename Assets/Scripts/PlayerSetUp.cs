using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetUp : NetworkBehaviour
{
    public Behaviour[] itemsToDisable;
	void Start ()
    {
		if(!isLocalPlayer)
        {
            for(int i = 0; i < itemsToDisable.Length; i++)
            {
                itemsToDisable[i].enabled = false;
            }
        }
	}
}
