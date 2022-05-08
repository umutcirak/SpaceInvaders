using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health playerHealth;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    [Header("Level")]
    [SerializeField] TextMeshProUGUI levelText;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        healthSlider.maxValue = playerHealth.GetHealth();
    }

   
    void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        healthSlider.value = playerHealth.GetHealth();
        scoreText.text = "" + scoreKeeper.GetScore();
        levelText.text = "Level: " + UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex; 
    }
}
