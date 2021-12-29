using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAndResume : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseScreen;
    public static bool paused;
    public KeyCode pauseButton;
    void Start()
    {
        paused = false;
        pauseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pauseButton) && !paused)
        {
            Pause();
        }
        else if (Input.GetKeyDown(pauseButton) && paused)
        {
            Resume();
        }

    }
    public void Pause()
    {
        pauseScreen.SetActive(true);
        paused = true;
        Time.timeScale = 0;
    }
    public void Resume()
    {
        pauseScreen.SetActive(false);
        paused = false;
        Time.timeScale = 1;
    }
   
}
