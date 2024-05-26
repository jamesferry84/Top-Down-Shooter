using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int currentScore = 0;

    private static ScoreKeeper instance;
    
    void Start()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

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
 


}
