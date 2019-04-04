using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject MenuButtons;
    public bool gamePaused = false;

    // Start is called before the first frame update
    void Start()
    {
        MenuButtons.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(MenuButtons)
        {
            if (Input.GetKeyDown("escape"))
            {
                gamePaused = !gamePaused;
                MenuButtons.SetActive(gamePaused);
            }

            if (gamePaused == false)
            {
                Time.timeScale = 1f;
            }
            if (gamePaused == true)
            {
                Time.timeScale = 0.0f;
            }
        }
    }

    public void ResumeGame()
    {
        gamePaused = false;
        MenuButtons.SetActive(false);
    }
}
