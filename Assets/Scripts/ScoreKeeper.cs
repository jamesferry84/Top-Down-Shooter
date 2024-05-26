using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int currentScore = 0;

    public int GetScore()
    {
        return currentScore;
    }

    public void UpdateScore(int value)
    {
        currentScore += value;
    }
    
    public void ResetScore()
    {
        currentScore = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
