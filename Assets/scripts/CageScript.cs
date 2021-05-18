using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CageScript : MonoBehaviour
{
    [SerializeField] Text m_Score;


    public delegate void ScoreEvent(int score);
    public event ScoreEvent OnScoreAdded = (s) => { };


    private int score;

    // Start is called before the first frame update
    void Awake()
    {
        OnScoreAdded += HandleOnScoreAdded;
    }


    private void HandleOnScoreAdded(int score)
    {
        ShowScore(score);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "spirit")
        {
            ChangeScore(1);
            OnScoreAdded(score);
         

        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "spirit")
        {
            ChangeScore(-1); 
            Debug.Log("Score:" + score);
            OnScoreAdded(score);
        }
    }

    public void ChangeScore(int i)
    {
        score = score + i;
        OnScoreAdded(score);
    }

    public void ShowScore(int score)
    {
        m_Score.text = score.ToString();
    }

}

