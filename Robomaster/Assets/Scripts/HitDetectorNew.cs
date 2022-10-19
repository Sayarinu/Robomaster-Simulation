using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetectorNew : MonoBehaviour
{
    public string nameIndication = "unknown name";
    string bulletType = "na";

    //For New Hits---------------
    float v;
    float g;
    float DropBlood;
    private float blinktime = 0f;
    bool Hitflag = false;
    //-----------------------------

    void DropHealth(float amount)
    {
        GetComponentInParent<BaseHealthNew>().DropHealth(amount, bulletType, nameIndication);
    }

    void OnCollisionEnter(Collision Hiter) //when hit collect hit value
    {
        //Debug.Log("I am hit by: " + Hiter.gameObject.name);
        v = Hiter.relativeVelocity.magnitude;
        g = Hiter.gameObject.GetComponent<Rigidbody>().mass;
        //Debug.Log(Hiter.gameObject.name + "'s g and v are " + g + " and " + v);
        if (g == 0.05f && v > 12f)
        {
            DropBlood = 400f;
            bulletType = "large fast";
        }
        if (g == 0.05f && v < 12f)
        {
            DropBlood = 150f;
            bulletType = "large slow";
        }
        if (g == 0.01f)
        {
            DropBlood = 100f;
            bulletType = "small";
        }

        if (DropBlood != 0) DropHealth(DropBlood);
        DropBlood = 0;
    }
}
