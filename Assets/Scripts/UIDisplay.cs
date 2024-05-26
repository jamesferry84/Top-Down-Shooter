using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private ScoreKeeper _scoreKeeper;
    private Health _health;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = currentScore.ToString();
    }
}
