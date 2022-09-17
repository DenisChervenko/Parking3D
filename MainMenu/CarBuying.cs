using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TMPro;

public class CarBuying : MonoBehaviour
{
    [SerializeField] private GameObject[] _car;

    [SerializeField] private GameObject[] _buyButton;
    [SerializeField] private GameObject[] _chooseButton;
    [SerializeField] private GameObject[] _wasSelectedButton;
    
    [SerializeField] private TMP_Text[] _priceText;
    [SerializeField] private int[] _price;
    [SerializeField] private int[] _carWasBuyed;

    [SerializeField] private string[] _playerPrefsCar;

    private int _carWasChoosen;

    [HideInInspector]
    public int balancePlayerCoin;
    [HideInInspector]
    public int balancePlayerGem;

    [Inject] BalanceRefresher balanceRefresher;

    private void Start()
    {
        _carWasBuyed[0] = 1;

        if(PlayerPrefs.HasKey("CoinBalance"))
            balancePlayerCoin = PlayerPrefs.GetInt("CoinBalance");
        if(PlayerPrefs.HasKey("GemBalance"))
            balancePlayerGem = PlayerPrefs.GetInt("GemBalance");
        if(PlayerPrefs.HasKey("WasSelected"))
            _carWasChoosen = PlayerPrefs.GetInt("WasSelected");

        DataHandler(false);

        AssignTextPrice();
        CheckForAvaliabillity();
    }

    private void AssignTextPrice()
    {
        for(int i = 0; i <= (_priceText.Length - 1); i++)
        {
            _priceText[i].text = Convert.ToString(_price[i]);
        }
    }

    private void CheckForAvaliabillity()
    {
        for(int i = 0; i <= (_car.Length - 1); i++)
        {
            if(_carWasBuyed[i] == 1)
            {
                _buyButton[i].SetActive(false);

                _chooseButton[i].SetActive(true);
            }
            else
            {
                _buyButton[i].SetActive(true);
                _chooseButton[i].SetActive(false);
            }
        }

        _chooseButton[_carWasChoosen].SetActive(false);
        _wasSelectedButton[_carWasChoosen].SetActive(true);
    }

    public void BuyCar(int indexCar)
    {
        if(CheckBalancePlayer(indexCar))
        {
            _buyButton[indexCar].SetActive(false);
            _chooseButton[indexCar].SetActive(true);

            _carWasBuyed[indexCar] = 1;

            DataHandler(true);

            bool isCoin = indexCar < 5 ? true : false;
            balanceRefresher.BuYCar(_price[indexCar], isCoin);
        }
    }

    public void SelectCar(int indexCar)
    {
        _chooseButton[_carWasChoosen].SetActive(true);
        _wasSelectedButton[_carWasChoosen].SetActive(false);

        _chooseButton[indexCar].SetActive(false);
        _wasSelectedButton[indexCar].SetActive(true);

        _carWasChoosen = indexCar;

        PlayerPrefs.SetInt("WasSelected", _carWasChoosen);
    }

    private bool CheckBalancePlayer(int indexCar)
    {
        if(indexCar <= 5)
        {
            if(balancePlayerCoin >= _price[indexCar])
            {
                balancePlayerCoin -= _price[indexCar];

                return true;
            }

            return false;
        }
        else
        {
            if(balancePlayerGem >= _price[indexCar])
            {
                balancePlayerGem -= _price[indexCar];

                return true;
            }

            return false;
        }
    }

    private void DataHandler(bool save)
    {
        if(save)
        {
            for(int i = 0; i <= (_playerPrefsCar.Length - 1); i++)
            {

                PlayerPrefs.SetInt(_playerPrefsCar[i], _carWasBuyed[i]);
            }
        }
        else
        {
            for(int i = 0; i <= (_playerPrefsCar.Length - 1); i++)
            {
                _carWasBuyed[i] = PlayerPrefs.GetInt(_playerPrefsCar[i], _carWasBuyed[i]);
            }
        }
    }
}
