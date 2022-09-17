using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ProgressBarController : MonoBehaviour
{
    [SerializeField] private Image[] _coinProgressBar;
    [SerializeField] private Image[] _stageProgressBar;

    [SerializeField] private float[] _countCoinForCompleteQuest;
    [SerializeField] private float[] _countStageForCompleteQuest;

    private int _coinCount;
    private int _stageCount;

    [Inject] LevelFinishDisplay levelFinishDisplay;

    private void Start()
    {
        _coinCount = PlayerPrefs.GetInt("GlobalBalance");
        _stageCount = levelFinishDisplay._wasFinishedStage;
        Debug.Log(_stageCount);

        for(int i = 0; i <= (_coinProgressBar.Length - 1); i++)
        {
            _coinProgressBar[i].fillAmount += 1/_countCoinForCompleteQuest[i] * _coinCount; 
            
        }   

        for(int i = 0; i <= (_stageProgressBar.Length - 1); i++)
        {
            _stageProgressBar[i].fillAmount += 1/_countStageForCompleteQuest[i] * _stageCount;
        }
    }
}
