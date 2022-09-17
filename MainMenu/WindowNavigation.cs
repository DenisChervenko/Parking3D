using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WindowNavigation : MonoBehaviour
{
    [SerializeField] private GameObject _island;

    [SerializeField] private GameObject[] _allUIelements;

    [SerializeField] private GameObject[] _uiComponentMenu;
    [SerializeField] private GameObject[] _uiComponentSetting;
    [SerializeField] private GameObject[] _uiComponentShop;
    [SerializeField] private GameObject[] _uiComponentQuest;

    [SerializeField] private GameObject _giftNotification;

    [SerializeField] private GameObject _notificationButtonIsActive;
    [SerializeField] private GameObject _notificationButtonIsDisabled;

    [SerializeField] private GameObject _soundButtonIsActive;
    [SerializeField] private GameObject _soundButtonIsDisabled;

    private int _windowWasOpened;

    [Inject] MusicSound musicSound;

    public void NavigationButton(int activeBranch)
    {
        for(int i = 0; i <= _allUIelements.Length - 1; i++)
        {
            _allUIelements[i].SetActive(false);
        }

        if(activeBranch == 0)
            _island.SetActive(true);
        else    
            _island.SetActive(false);

        ActiveInterfaceComponent(activeBranch);

        _giftNotification.SetActive(false);

        if(activeBranch == 1)
        {
            if(PlayerPrefs.GetInt("NotificationActive") == 1)
                _notificationButtonIsActive.SetActive(false);
            else
                _notificationButtonIsDisabled.SetActive(true);

            if(PlayerPrefs.GetInt("SoundActive") == 1)
                _soundButtonIsActive.SetActive(false);
            else
                _soundButtonIsDisabled.SetActive(true);
        }
    }

    private void ActiveInterfaceComponent(int index)
    {
        if(index == 0)
            for(int i = 0; i <= (_uiComponentMenu.Length - 1); i++)
                _uiComponentMenu[i].SetActive(true);
        else if(index == 1)
            for(int i = 0; i <= (_uiComponentSetting.Length - 1); i++)
                _uiComponentSetting[i].SetActive(true);
        else if(index == 2)
            for(int i = 0; i <= (_uiComponentShop.Length - 1); i++)
                _uiComponentShop[i].SetActive(true);
        else
            for(int i = 0; i <= (_uiComponentQuest.Length - 1); i++)
                _uiComponentQuest[i].SetActive(true);
                
    }
}
