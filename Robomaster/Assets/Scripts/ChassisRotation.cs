using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChassisRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float rotate = 1.0f;
        if(Input.GetButtonDown("Q")){
          transform.Rotate(0f,rotate*Time.deltaTime, 0f, Space.Self);
        }
        else if (Input.GetButtonDown("E")) {
          transform.Rotate(0f,-1*rotate*Time.deltaTime, 0f, Space.Self);
        }

        //transform.localRotation = Quaternion.Euler(10f, 0, 0);
    }
}
