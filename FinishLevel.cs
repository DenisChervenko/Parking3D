using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Zenject;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] private int _countCarForFinishLevel;
    private int _carWasFinished;

    [Inject] AddBalance addBalance;
    [Inject] WinScreen winScreen;

    private void CarOnFinish()
    {
        _carWasFinished++;

        if(_carWasFinished == _countCarForFinishLevel)
        {
            LevelChanger();

            addBalance.SaveBalance();
            winScreen.ShowWinScreen();
        }
    }

    private void LevelChanger()
    {
        winScreen._levelWasFinished = SceneManager.GetActiveScene().buildIndex;

        if(winScreen._levelWasFinished % 5 == 0 && winScreen._levelWasFinished != 0)
        {
            SceneManager.LoadScene(0);
        }

        PlayerPrefs.SetInt("LevelIndexFinish", winScreen._levelWasFinished);
        PlayerPrefs.SetInt("LevelFirstComlplete", 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("CarHorizontal") || other.gameObject.CompareTag("CarVertical"))
        {
            CarOnFinish();
        }
    }
}
