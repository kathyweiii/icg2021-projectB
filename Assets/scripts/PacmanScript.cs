using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PacmanScript : MonoBehaviour
{
    float speed = 5f;
    Collider[] food;
    int pointIndex = 1;
    Vector3 NextPoint;
    Vector3 LookDirection;
    Quaternion targetLook;
    bool havingFood = false;
    bool noMoreFood = false;
    public int m_score;
    //[SerializeField] GameObject m_cage;
    
     
    // Start is called before the first frame update
    void Start()
    {
       
        //GetNearest();
        //this.GetComponent<pacman>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(havingFood == true)
            moveForward();
        if (noMoreFood)
            speed = 0f;

    }

    public void GetNearest()
    {

        int SearchRadius = 50;
        food = Physics.OverlapSphere(this.transform.position, SearchRadius, 1 << LayerMask.NameToLayer("food"));
        if (food.Length > 0)
        {
            havingFood = true;
            Debug.Log(food.Length);
            for (int i = 0; i < food.Length; i++)
            {
                Debug.Log("index: " + i);
                Debug.Log("position:" + food[i].transform.position);
            }
        }
        else
            Debug.Log("there is no food");
      
    }



    public void moveForward()
    {
        //nextPoint();
        //LookDirection = coll[pointIndex].transform.position - this.transform.position;
        LookDirection = this.transform.position- food[pointIndex-1].transform.position;
        targetLook = Quaternion.LookRotation(LookDirection);

        this.transform.rotation = targetLook;
        this.transform.Translate(Vector3.back * Time.deltaTime * speed);
        //this.transform.rotation = Quaternion.Slerp(this.transform.rotation,targetLook,Time.deltaTime*speed);

    }


    public void OnTriggerEnter(Collider other)
    {
        GameObject cage = GameObject.Find("cage");
        CageScript cageScript = cage.GetComponent<CageScript>();
        //m_score = cageScript.score;
        if (other.tag == "cage")//pacman enters cage
        {
            GetNearest();
        }
        if (other.transform.position == food[pointIndex-1].transform.position)//pacman eats food
        {
            if (pointIndex == food.Length)//eat the last one
            {
                havingFood = false;
                noMoreFood = true;
                Destroy(other.gameObject);
                cageScript.ChangeScore(-1);
                //m_score--;
                Debug.Log("no more food.");
                
            }
            else
            {
                Debug.Log("i'm eating food" + pointIndex);
                Destroy(other.gameObject);
                cageScript.ChangeScore(-1);
                pointIndex++;
                Debug.Log("I'm going to eat food" + pointIndex);
            }
          
        }
      
    }

    

}
