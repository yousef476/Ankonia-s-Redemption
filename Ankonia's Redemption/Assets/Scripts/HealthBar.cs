using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Image live1;
    public Image live2;
    public Image live3;
    public void SetMaxHealth(int health){
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(int health){
        slider.value = health;
    }

    public void SetLives(int currentLives){
        
        if (currentLives == 2)
        {
           Destroy(live3);
        }
        else if (currentLives == 1)
        {
            Destroy(live2);
        }
        else
        {
            Destroy(live1);
        }
    }
}
