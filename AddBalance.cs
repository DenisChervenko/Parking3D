using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddBalance : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinBalanceText;
    [SerializeField] private TMP_Text _gemBalanceText;

    [HideInInspector]
    public int balancePlayerGem;
    [HideInInspector]
    public int balanacePlayerCoin;

    private int _currentBalanceCoin;
    private int _currentBalanceGem;

    private void Start()
    {
        _currentBalanceCoin = PlayerPrefs.GetInt("CoinBalance");
        _currentBalanceGem = PlayerPrefs.GetInt("GemBalance");
    }

    public void AddPlayerBalance(bool isCoin, int reward)
    {
        if(isCoin)
        {
            balanacePlayerCoin += reward;
            _coinBalanceText.text = Convert.ToString(balanacePlayerCoin);
        }
        else
        {
            balancePlayerGem += reward;
            _gemBalanceText.text = Convert.ToString(balancePlayerGem);
        }
    }

    public void SaveBalance()
    {
        _currentBalanceCoin += balanacePlayerCoin;
        _currentBalanceGem += balancePlayerGem;

        PlayerPrefs.SetInt("CoinBalance", _currentBalanceCoin);
        PlayerPrefs.SetInt("GemBalance", _currentBalanceGem);
    }
}
