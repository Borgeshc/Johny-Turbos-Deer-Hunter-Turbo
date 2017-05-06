using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialWrangler : MonoBehaviour
{
    public GameObject tutorialMenu;
    public GameObject gameUI;

    public GameObject player;
    public GameObject gameManager;

    public GameObject pressSpaceToStart;

    bool canChangeState;

	
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            player.SetActive(true);
            gameUI.SetActive(true);
            gameManager.SetActive(true);
            tutorialMenu.SetActive(false);
        }

        if(!canChangeState)
        {
            canChangeState = true;
            if(gameObject.activeSelf)
            StartCoroutine(ChangeActiveState());
        }
	}

    IEnumerator ChangeActiveState()
    {
        pressSpaceToStart.SetActive(!pressSpaceToStart.activeSelf);
        yield return new WaitForSeconds(.5f);
        canChangeState = false;
    }
}
