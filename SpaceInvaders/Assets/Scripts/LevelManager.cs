using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float delay = 1f;

    ScoreKeeper scoreKeeper;
   

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();        
    }   

   

    public void LoadGame()
    {
        scoreKeeper.ResetScore();
        StartCoroutine(WaitAndLoad("Level 1"));
    }
    public void LoadMainMenu()
    {        
        StartCoroutine(WaitAndLoad(0));
    }

    public void LoadGameOverMenu()
    {        
        StartCoroutine(WaitAndLoad("GameOver Menu"));
    }

    public void LoadNextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        //Debug.Log(currentScene);
        //Debug.Log(SceneManager.sceneCountInBuildSettings);

        if (currentScene <= SceneManager.sceneCountInBuildSettings - 2)
        {            
            SceneManager.LoadScene(currentScene + 1);
        }
        else
        {
            SceneManager.LoadScene("GameOver Menu");
        }
    }    
           

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
    IEnumerator WaitAndLoad(int sceneIndex)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneIndex);
    }

    


}
