using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trolley : MonoBehaviour
{

    const float MOVE_SPEED = 2f;
    const float MAX_LIMIT = -0.01119985f;
    const float MIN_LIMIT = -0.1710316f;
    float m_Position;

    void Update()
    {

        m_Position = this.transform.localPosition.y;

        if (Input.GetKey(KeyCode.Q))
        {
            if (m_Position < MAX_LIMIT)
            {
                this.transform.Translate(0, 0, -MOVE_SPEED * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.E))
        {
            if (m_Position > MIN_LIMIT)
            {
                this.transform.Translate(0, 0, MOVE_SPEED * Time.deltaTime);
            }
        }
    }
}
