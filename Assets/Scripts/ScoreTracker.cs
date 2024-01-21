using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    [SerializeField] private int maxScore = 3;
    [SerializeField] private float width = 60f;
    [SerializeField] private float height = 12.5f;
    [SerializeField] private float offsetFromCenter = 5f;
    [SerializeField] private GameObject ball;
    [SerializeField] private TextMeshPro gameOverTextField;
    
    private int score1,score2;
    public int Score1 
    { 
        get 
        {
            return score1;
        } 
        set 
        {
            score1 = value;
            if(score1 == maxScore)
            {
                DeclareWinner("Left Player");
            }
        }
    }

    public int Score2
    { 
        get 
        {
            return score2;
        } 
        set 
        {
            score2 = value;
            if(score2 == maxScore)
            {
                DeclareWinner("Right Player");
            }
        }
    }

    void Start()
    {
        score1 = 0;
        score2 = 0;
    }

    public void DeclareWinner(string winner)
    {
        string msg = string.Format("{0} Wins!",winner);
        ball.GetComponent<BallLogic>().Speed = 0f; // i.e freeze the ball.
        gameOverTextField.text = msg;
    }
}
