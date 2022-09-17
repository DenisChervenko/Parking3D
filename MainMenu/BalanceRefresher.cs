using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BalanceRefresher : MonoBehaviour
{
    [SerializeField] private TMP_Text _balanceCoinText;
    [SerializeField] private TMP_Text _balanceGemText;

    private int _currentCoinBalance;
    private int _currentGemBalance;
    private int _globalBalance;

    private void Awake()
    {
        _currentCoinBalance = PlayerPrefs.GetInt("CoinBalance");
        _currentGemBalance = PlayerPrefs.GetInt("GemBalance");

        GlobalBalance();

        _balanceCoinText.text = Convert.ToString(_currentCoinBalance);
        _balanceGemText.text = Convert.ToString(_currentGemBalance);
    }

    private void GlobalBalance()
    {
        if(PlayerPrefs.HasKey("GlobalBalance"))
            _globalBalance = PlayerPrefs.GetInt("GlobalBalance");

        if(_globalBalance < _currentCoinBalance)
        {
            _globalBalance = _currentCoinBalance; 
        }

        PlayerPrefs.SetInt("GlobalBalance", _globalBalance);
    }

    public void BuYCar(int carCost, bool isCoin)
    {
        if(isCoin)
        {
            _currentCoinBalance -= carCost;
            _balanceCoinText.text = Convert.ToString(_currentCoinBalance);
        }
        else
        {
            _currentGemBalance -= carCost;
            _balanceGemText.text = Convert.ToString(_currentGemBalance);
        }

        SaveBalance();
    }

    public void GetRewardFromQuest(int countReward, bool isCoin)
    {
        if(isCoin)
        {
            _currentCoinBalance += countReward;
            _balanceCoinText.text = Convert.ToString(_currentCoinBalance);
        }
        else
        {
            _currentGemBalance += countReward;
            _balanceGemText.text = Convert.ToString(_currentGemBalance);
        }

        SaveBalance();
    }

    public void SaveBalance()
    {
        PlayerPrefs.SetInt("CoinBalance", _currentCoinBalance);
        PlayerPrefs.SetInt("GemBalance", _currentGemBalance);
    }
}
