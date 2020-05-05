using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [Header("GameOverUI")]
    public GameObject GameOverPanal;
    public GameObject RestartLevel;
    public GameObject NextLevel;

    [Header("Current Level")]
    public int currentLevel;

    private void Start()
    {
        instance = this;
        GameOverPanal.SetActive(false);
        RestartLevel.SetActive(false);
        NextLevel.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void Restart()
    {
        //Restart same level after rester click
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void loadLevel()
    {
        StartCoroutine(load());
    }

    IEnumerator load()
    {
        //load next level every time 
        yield return new WaitForSeconds(0f);
        SceneManager.LoadScene(currentLevel + 1);
    }
}
