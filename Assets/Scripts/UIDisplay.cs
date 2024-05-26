using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Slider slider;
    private ScoreKeeper _scoreKeeper;
    private Health _health;
    private float maxHealth;

    private void Awake()
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
        _health = FindObjectOfType<Health>();
        maxHealth = _health.GetHealth();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text =_scoreKeeper.GetScore().ToString("00000000");
        slider.value = _health.GetHealth() / maxHealth;
    }
}
