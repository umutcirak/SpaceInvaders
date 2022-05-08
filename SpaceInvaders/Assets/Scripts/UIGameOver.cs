using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIGameOver : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI scoreText;

    ScoreKeeper scoreKeeper;


    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        scoreText.text = "YOUR SCORE: \n" + scoreKeeper.GetScore();
    }   

}
