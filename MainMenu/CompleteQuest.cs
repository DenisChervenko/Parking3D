using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CompleteQuest : MonoBehaviour
{
    [SerializeField] private int _reward;
    [SerializeField] private bool _isCoin;

    [SerializeField] private string _saveKey;
    private int _willBeUsed;

    [Inject] BalanceRefresher balanceRefresher;
    [Inject] CarBuying carBuying;

    private void Start()
    {
        _willBeUsed = PlayerPrefs.GetInt(_saveKey);

        if(_willBeUsed == 1)
        {
            gameObject.SetActive(false);
        }
    }

    public void QuestComplete()
    {
        balanceRefresher.GetRewardFromQuest(_reward, _isCoin);
        PlayerPrefs.SetInt(_saveKey, 1);
        gameObject.SetActive(false);

        if(_isCoin)
            carBuying.balancePlayerCoin += _reward;
        else    
            carBuying.balancePlayerGem += _reward;
    }
}
