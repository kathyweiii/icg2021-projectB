using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jib : MonoBehaviour
{
    const float MOVE_SPEED = 10f;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Rotate(0, -MOVE_SPEED * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Rotate(0, MOVE_SPEED * Time.deltaTime, 0);
        }
    }
}