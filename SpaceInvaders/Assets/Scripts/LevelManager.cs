using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float delay = 1f;
    
    public void LoadGame()
    {        
        StartCoroutine(WaitAndLoad("Level 1"));
    }
    public void LoadMainMenu()
    {        
        StartCoroutine(WaitAndLoad("MainMenu"));
    }

    public void LoadGameOverMenu()
    {        
        StartCoroutine(WaitAndLoad("GameOver Menu"));
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


}
