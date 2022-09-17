using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class StartLevel : MonoBehaviour
{
    private int _levelWillStart = 1;

    //0 false 1 true
    private int _isFirstLevelWillbeFinished = 0;

    private void Start()
    {
        if(PlayerPrefs.HasKey("LevelIndexFinish"))
        {
            _levelWillStart = PlayerPrefs.GetInt("LevelIndexFinish");
        }

        if(PlayerPrefs.HasKey("LevelFirstComlplete"))
        {
            _isFirstLevelWillbeFinished = 1;
        }
    }

    public void PlayGame()
    {
        if(_isFirstLevelWillbeFinished == 0)
            SceneManager.LoadScene(_levelWillStart);
        else   
            SceneManager.LoadScene(_levelWillStart + 1);
    }
}
