using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DailyGift : MonoBehaviour
{
    [SerializeField] private GameObject _rewardButton;
    [SerializeField] private GameObject _rewardImage;

    [SerializeField] private int _reward;

    [Inject] BalanceRefresher balanceRefresher;
    [Inject] MusicSound musicSound;
    [Inject] CarBuying carBuying;

    private int _alreadyTaked = 0;

    private void Start()
    {
        if(PlayerPrefs.HasKey("Gift"))
        {
            _alreadyTaked = PlayerPrefs.GetInt("Gift");
        }

        if(_alreadyTaked == 1)
        {
            _rewardButton.SetActive(false);
        }
    }

    public void OnClickGetReward()
    {
        _rewardImage.SetActive(true);
        _rewardButton.SetActive(false);

        musicSound.ActiveCoinSound();
        balanceRefresher.GetRewardFromQuest(10, true);

        _alreadyTaked = 1;
        PlayerPrefs.SetInt("Gift", _alreadyTaked);

        carBuying.balancePlayerCoin += _reward;
    }
}
