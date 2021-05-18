using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrolleyJointBody : MonoBehaviour {

    const float MOVE_SPEED = 2f;
    float distance;

    void Start() {
        var limit = this.GetComponent<ConfigurableJoint>().linearLimit;
        limit.limit = 0;
    }
    
    void Update() {

        // Control
        var limit = this.GetComponent<ConfigurableJoint>().linearLimit;
        
        if (Input.GetKey(KeyCode.UpArrow)) {
            limit.limit -= MOVE_SPEED * Time.deltaTime;
            this.GetComponent<ConfigurableJoint>().linearLimit = limit;
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            limit.limit += MOVE_SPEED * Time.deltaTime;
            this.GetComponent<ConfigurableJoint>().linearLimit = limit;
        }
    }
}