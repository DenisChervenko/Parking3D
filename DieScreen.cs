using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class DieScreen : MonoBehaviour
{
    [SerializeField] private GameObject _dieScreen;
    [Inject] TimeScaleController timeScaleController;

    public void ShowDieScreen()
    {
        _dieScreen.SetActive(true);
        timeScaleController.TimeStop();
    }

    public void RestartButton()
    {
        timeScaleController.TimeResume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ToMainMenu()
    {
        timeScaleController.TimeResume();
        SceneManager.LoadScene(0);
    }
}
