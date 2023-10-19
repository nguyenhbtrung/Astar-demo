using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipperImage : MonoBehaviour
{
    float delay;
    Vector3 previousPos;

    private void Awake()
    {
        delay = 0;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(90, 0, 0);
        if (delay >= 0.5f)
        {
            if (transform.position.x > previousPos.x)
            {
                transform.localScale = new Vector3(3, 3, 0);
                delay = 0;
            }
            else if (transform.position.x < previousPos.x)
            {
                transform.localScale = new Vector3(-3, 3, 0);
                delay = 0;
            }
        }
        delay += Time.deltaTime;
        previousPos = transform.position;
    }
}
