using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable : MonoBehaviour {
    [SerializeField] GameObject hook;
    [SerializeField] GameObject trolley;
    
    void Start() {
        this.GetComponent<LineRenderer>().material.color = Color.black;
    }
    
    void Update() {
        this.GetComponent<LineRenderer>().SetPosition(0, trolley.transform.position);
        this.GetComponent<LineRenderer>().SetPosition(1, hook.transform.position);
    }
}
