using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float m_Speed = 1f;
    private int funCounter = 0;
    private bool goingLeft = false;

    private Rigidbody rb;

    private Vector3 startPositionRight;
    private Vector3 endPositionRight = new Vector3((float)-1.55, (float)1.18, (float)-2.9);
    private float desiredDurationRight = 2f;
    private float elapsedTimeRight;
    void Start()
    {
//         rb = GetComponent<Rigidbody>();
        startPositionRight = transform.position;
    }


    void MoveRight()
    {
//         if(funCounter < 30) {
//             if(goingLeft)
//                 rb.AddForce(Vector3.left * 0.01f);
//             else
//                 rb.AddForce(Vector3.right * 0.01f);
//             funCounter++;
//         }
//         else {
//             funCounter = 0;
//             goingLeft = !goingLeft;
//         }
        elapsedTimeRight += Time.deltaTime;
        float percentageComplete = elapsedTimeRight / desiredDurationRight;
        transform.position = Vector3.Lerp(startPositionRight, endPositionRight, percentageComplete);

    }

     Vector3 pointA = new Vector3((float)-2.90, (float)1.52, (float)-1.70);
     Vector3 pointB = new Vector3((float)-1.65, (float)1.52, (float)-2.97);
    // Update is called once per frame
    void Update()
    {
//         MoveRight();

        transform.position = Vector3.Lerp(pointA, pointB, Mathf.PingPong(Time.time * m_Speed, 1));
    }
}
