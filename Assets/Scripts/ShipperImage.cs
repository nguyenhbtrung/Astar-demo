using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipperImage : MonoBehaviour
{

    Vector3 previousPos;

    private void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(90, 0, 0);
        transform.position = transform.parent.position + new Vector3(0, 6, 6);
        if (transform.position.x > previousPos.x)
        {
            transform.localScale = new Vector3(3, 3, 0);
        }
        else if (transform.position.x < previousPos.x)
        {
            transform.localScale = new Vector3(-3, 3, 0);
        }
        previousPos = transform.position;
    }
}
