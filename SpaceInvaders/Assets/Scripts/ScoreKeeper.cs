using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    
    private int score;
    [SerializeField] int scoreMultiplier = 10;
    [SerializeField] int damageScore = 10;
    [SerializeField] int killScore = 250;


    static ScoreKeeper instance;

    void Awake()
    {
        ManageSingleton();
    }    

    void ManageSingleton()
    {
        
        if(instance != null)
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

    void Start()
    {
        score = 0;
    }

    public int GetScore()
    {
        return score;
    }

    public void ModifyScore()
    {
        score += damageScore * scoreMultiplier;       
    }

    public void ModifyScoreKill()
    {
        score += killScore * scoreMultiplier;        
    }

    public void ResetScore()
    {
        score = 0;
    }

}
