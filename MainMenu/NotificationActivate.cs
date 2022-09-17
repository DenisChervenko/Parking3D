using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class NotificationActivate : MonoBehaviour
{
    [SerializeField] private GameObject _notificationIsNowActive;
    [SerializeField] private GameObject _notificationIsNowDisable;

    [SerializeField] private GameObject _notificationObject;

    [Inject] MusicSound musicSound;

    public void Active(bool active)
    {
        _notificationObject.SetActive(active);

        if(!_notificationObject.activeSelf)
        {
            _notificationIsNowActive.SetActive(false);
            _notificationIsNowDisable.SetActive(true);

            PlayerPrefs.SetInt("NotificationActive", 1);
        }
        else
        {
            _notificationIsNowActive.SetActive(true);
            _notificationIsNowDisable.SetActive(false);

            PlayerPrefs.SetInt("NotificationActive", 0);
        }

        musicSound.ButtonPressSound();
    }
}
