using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BarrierPass : MonoBehaviour
{
    [SerializeField] private GameObject _barrier;
    [SerializeField] private bool[] _carOnExit;

    private int _currentTurnArray;
    private int _missingCar;

    private bool _barrierWasLifted = false;

    private Animator _animator;

    private void Start()
    {
        _animator = _barrier.GetComponent<Animator>();
    }

    public void CarPassController(bool onParkingPlace)
    {
        if(_currentTurnArray > (_carOnExit.Length - 1))
        {
            _currentTurnArray = 0;
        }

        _carOnExit[_currentTurnArray] = onParkingPlace == true ? true : false;

        if(onParkingPlace)
        {
            _currentTurnArray++;
            ChekingForThoesPresent();
        }
        else
        {
            _currentTurnArray--;
            ChekingForMissingCar();
        }
    }

    private void ChekingForThoesPresent()
    {
        if(!_barrierWasLifted)
        {   
            _animator.SetTrigger("Open");
            _barrierWasLifted = true;
        }
    }

    private void ChekingForMissingCar()
    {
        for(int i = 0; i <= (_carOnExit.Length - 1); i++)
        {
            if(_carOnExit[i] == false)
            {
                _missingCar++;
            }
        }

        if(_missingCar == (_carOnExit.Length - 1))
        {
            _animator.SetTrigger("Close");
            _barrierWasLifted = false;
        }

        _missingCar = 0;
    }
}
