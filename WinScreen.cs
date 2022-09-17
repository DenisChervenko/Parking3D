using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private GameObject _winScreen;

    [HideInInspector]
    public int _levelWasFinished;

    [Inject] TimeScaleController timeScaleController;

    public void ShowWinScreen()
    {
        _winScreen.SetActive(true);
        timeScaleController.TimeStop();
    }

    public void ToNextLevel()
    {
        timeScaleController.TimeResume();
        SceneManager.LoadScene(_levelWasFinished + 1);
    }

    public void ToMainMenu()
    {
        timeScaleController.TimeResume();
        SceneManager.LoadScene(0);
    }
}
