using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealthNew : MonoBehaviour
{
    public float FullHealth = 5000;
    float CurrentHealth;



    void Start()
    {
        CurrentHealth = FullHealth;
        Debug.Log("Current Heath is: " + CurrentHealth);
    }

    public void DropHealth(float amount, string bulletType, string detector)
    {
        CurrentHealth -= amount;
        Debug.Log("Current Heath is: " + CurrentHealth + 
            " \r\n just got hit " + amount + 
            " \r\n detected by " + detector + 
            " \r\n bullet type: " + bulletType );
    }

}
