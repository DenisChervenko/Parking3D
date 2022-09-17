using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SoundActivate : MonoBehaviour
{
    [SerializeField] private GameObject _soundNowIsActivate;
    [SerializeField] private GameObject _soundNowIsDisabled;

    [SerializeField] private GameObject _soundObject;

    [Inject] MusicSound musicSound;

    public void Active(bool active)
    {
        _soundObject.SetActive(active);

        if(!_soundObject.activeSelf)
        {
            _soundNowIsActivate.SetActive(false);
            _soundNowIsDisabled.SetActive(true);

            PlayerPrefs.SetInt("SoundActive", 1);
        }
        else
        {
            _soundNowIsActivate.SetActive(true);
            _soundNowIsDisabled.SetActive(false);

            PlayerPrefs.SetInt("SoundActive", 0);
        }

        musicSound.ButtonPressSound();
    }
}
