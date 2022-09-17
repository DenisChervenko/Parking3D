using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelFinishDisplay : MonoBehaviour
{
    [SerializeField] private GameObject[] _uiLevelDisplay;
    [SerializeField] private GameObject[] _islandMesh;
    [SerializeField] private TMP_Text _levelWasFinish;

    [HideInInspector]
    public int _wasFinishedStage;

    private int _countLevelWasFinished;
    private int _countLevelWasDisplay;

    private void Awake()
    {
        if(PlayerPrefs.HasKey("LevelIndexFinish"))
        {
            _countLevelWasFinished = PlayerPrefs.GetInt("LevelIndexFinish");
        }

        for(int i = 0; i <= _countLevelWasFinished; i++)
        {
            if(i % 5 == 0 && i != 0)
            {
                _wasFinishedStage++;
            }


            if(i >= _countLevelWasFinished)
            {
                if(_wasFinishedStage != 0)
                {
                    for(int j = 0; j <= _wasFinishedStage; j++)
                    {
                        _islandMesh[j].SetActive(false);
                        _uiLevelDisplay[j].SetActive(false);

                        if(j >= _wasFinishedStage)
                        {
                            _islandMesh[j].SetActive(true);
                            _uiLevelDisplay[j].SetActive(true);
                        }
                    }
                }
            }
        }

        if(_wasFinishedStage != 0)
        {
            for(int i = 1; i <= _countLevelWasFinished; i++)
            {
                _countLevelWasDisplay++;

                if(_countLevelWasDisplay == 5)
                {
                    _countLevelWasDisplay = 0;
                }
            }
        }
        else
        {
            _countLevelWasDisplay = _countLevelWasFinished;
        }
        
        _levelWasFinish.text = Convert.ToString(_countLevelWasDisplay);

        if(_wasFinishedStage == 3)
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene(0);
        }
    }
}
