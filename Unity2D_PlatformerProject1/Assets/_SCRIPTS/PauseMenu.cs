using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseUI;

    //creating a private bool so nothing but this script can access the bool.
    private bool paused = false;

    void Start()
    {
        //setting it so that when we start the game the pause menu is disabled.
        PauseUI.SetActive(false);

    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            //this is togglight the bool "paused". Press one time = enabled, press again = disabled.
            paused = !paused;
        }

        //if the game is paused
        if (paused)
        {
            //enble the pause UI
            PauseUI.SetActive(true);
            //this is setting the time to 0 so when the game is paused time is not progressing; Nothing is happening.
            Time.timeScale = 0;
        }
        //if the game is not paused
        if (!paused)
        {
            //hide (disable) the PauseUI
            PauseUI.SetActive(false);
            //this is setting the time to 1. 1 because 1 is default time progression aka normal
            Time.timeScale = 1;
        }
    }
}
