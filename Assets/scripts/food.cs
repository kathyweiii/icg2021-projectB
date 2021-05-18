using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food : MonoBehaviour
{
    Rigidbody m_Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "cage_floor")
        {
            m_Rigidbody.isKinematic = true;
            this.gameObject.GetComponent<SphereCollider>().isTrigger = true;
            this.gameObject.layer = LayerMask.NameToLayer("food");

        }
    }
}
