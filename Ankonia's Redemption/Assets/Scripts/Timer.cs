using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    float currentTime = 0f;
    public float startTime;
    [SerializeField] Text countDown;
    public bool paused = false;
    void Start()
    {
        currentTime = startTime;

    }

    // Update is called once per frame
    void Update()
    {
       // if (!PauseAndResume.paused)
       // {
            currentTime -= 1 * Time.deltaTime;
            countDown.text = currentTime.ToString("0");


            if (currentTime >= 3.5f)
            {
                countDown.color = Color.green;
            }
            else if (currentTime < 3.5f)
            {
                countDown.color = Color.red;
            }
            if (currentTime <= 0)
            {
                currentTime = 0;
            }
            if (paused == true)
            {
                Time.timeScale = 0;

            }

            if (currentTime <= 0 && paused == false)
            {
                Lose();
            }
       // }


    }
    void Lose()
    {
        FindObjectOfType<PlayerStats>().Die();


    }
}
