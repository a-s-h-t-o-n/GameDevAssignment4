using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMovePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x == -10.0f && transform.position.y <= 5.0f)
        {
            lerpMethod(new Vector3(-10.0f, 1.0f, 0.0f), new Vector3(-10.0f, 5.0f, 0.0f), 3.0f);
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
        else if (transform.position.x == -10.0f && transform.position.y < 5.0f)
        {
            lerpMethod(new Vector3(-10.0f, 5.0f, 0.0f), new Vector3(0.0f, -5.0f, 0.0f), 3.0f);
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 270.0f);
        }
        else if (transform.position.x <= -5.0f && transform.position.y == 1.0f)
        {
            lerpMethod(new Vector3(-5.0f, 1.0f, 0.0f), new Vector3(-10.0f, 1.0f, 0.0f), 3.0f);
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
        }
        else if (transform.position.x == -5.0f && transform.position.y <= 0.0f)
        {
            lerpMethod(new Vector3(0.0f, -5.0f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f), 3.0f);
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }

        if (transform.position == new Vector3(-5.0f, 1.0f, 0.0f) || transform.position == new Vector3(-10.0f, 1.0f, 0.0f) || transform.position == new Vector3(-10.0f, 5.0f, 0.0f) || transform.position == new Vector3(-5.0f, 5.0f, 0.0f))
        {
            startTime = Time.time;
            
        }
    }

    void lerpMethod(Vector3 StartPos, Vector3 EndPos, float duration)
    {
        transform.position = Vector3.Lerp(StartPos, EndPos, (Time.time - startTime) / duration);
    }
}
