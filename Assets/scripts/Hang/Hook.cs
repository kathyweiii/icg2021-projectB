using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour {

    const float MOVE_SPEED = 2f;
    const float ATTACH_DISTANCE = 1f;
    GameObject m_DetectedObject; // 被打到的東西
    ConfigurableJoint m_JointForObject; // 加在joint body上的component


    void Update() {

        // Objects interaction
        if (m_JointForObject == null) {
            DetectObjects();
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            AttachOrDetachObject();
        }

    }

    void DetectObjects() {
        Ray ray = new Ray(this.transform.position, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, ATTACH_DISTANCE)) {
            if (m_DetectedObject == hit.collider.gameObject) {
                return;
            }
            RecoverDetectedObject();

            if (hit.collider.gameObject.tag == "spirit" || hit.collider.gameObject.tag == "pacman")
            {
                MeshRenderer renderer = hit.collider.GetComponent<MeshRenderer>();
                if (renderer != null)
                {
                    renderer.material.color = Color.yellow;
                    m_DetectedObject = hit.collider.gameObject;
                }
            }
        } else {
            RecoverDetectedObject();
        }
    }

    void RecoverDetectedObject() {
        if (m_DetectedObject != null) {
            if (m_DetectedObject.tag == "spirit")
            {
                m_DetectedObject.GetComponent<MeshRenderer>().material.color = Color.white;
            }
            m_DetectedObject = null;
        }
    }

    void AttachOrDetachObject() {
        if (m_JointForObject == null)
        { // Attach
            if (m_DetectedObject != null)
            {
                // Create a configurable joint then joint them
                ConfigurableJoint joint = this.gameObject.AddComponent<ConfigurableJoint>();
                joint.xMotion = ConfigurableJointMotion.Locked; // limited: 設定一個距離
                joint.yMotion = ConfigurableJointMotion.Locked;
                joint.zMotion = ConfigurableJointMotion.Locked;
                joint.angularXMotion = ConfigurableJointMotion.Free;
                joint.angularYMotion = ConfigurableJointMotion.Free;
                joint.angularZMotion = ConfigurableJointMotion.Free;


                joint.autoConfigureConnectedAnchor = false;
                if (m_DetectedObject.tag == "pacman") {
                    joint.connectedAnchor = new Vector3(0f, 0f, 0f);
                }
                if (m_DetectedObject.tag == "spirit") {
                    joint.connectedAnchor = new Vector3(0f, 0.7f, 0f);
                }
                    
                

                joint.connectedBody = m_DetectedObject.GetComponent<Rigidbody>();

                m_JointForObject = joint;

                if (m_DetectedObject.tag == "spirit")
                {
                    m_DetectedObject.GetComponent<MeshRenderer>().material.color = Color.red;
                }
                m_DetectedObject = null;
            }
        }
        else
        { // Detach
            if (m_JointForObject.tag == "spirit")
            {
                m_JointForObject.connectedBody.GetComponent<MeshRenderer>().material.color = Color.white;
            }
            GameObject.Destroy(m_JointForObject);
            m_JointForObject = null;
        }

       
    }

    
}