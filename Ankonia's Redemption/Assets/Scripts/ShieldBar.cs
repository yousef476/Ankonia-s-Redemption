using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    public Slider slider;
    public float currentTime;
    public float startingTime = 5f;

    void Start()
    {
        currentTime = startingTime;
        
    }


    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        for (float i = currentTime; i > 0; i--)
       {
            slider.maxValue = i;
            slider.value = i;
           
        }
       
    }

   

   

}
