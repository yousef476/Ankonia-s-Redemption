using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    float currentTime = 0f;
    float startTime = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1*Time.deltaTime;
    }
}
