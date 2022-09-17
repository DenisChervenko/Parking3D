using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DOtweenCarMovement : MonoBehaviour
{
    [SerializeField] private float _distanceMove;

    [SerializeField] private GameObject _frontTrigger;
    [SerializeField] private GameObject _backTrigger;

    private string _directionTrigger;

    private bool _alreadyOnRoad = false;

    private Rigidbody _rb;
    private Sequence _sequence;

    CarOnRoad carOnRoad;

    private void Start()
    {
        _sequence = DOTween.Sequence();
        carOnRoad = gameObject.GetComponent<CarOnRoad>();
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    public void MoveCarHorizontal(int directionCar)
    {
        _rb.angularVelocity = Vector3.zero;
        _rb.velocity = Vector3.zero;

        Vector3 direction = new Vector3(directionCar == 0 || directionCar == 2 ? (gameObject.transform.position.x - _distanceMove) : (gameObject.transform.position.x + _distanceMove), 
        gameObject.transform.position.y, gameObject.transform.position.z);
        _sequence.Append(gameObject.transform.DOMove(direction, 10).SetSpeedBased().SetEase(Ease.Linear).OnComplete(() => 
        {
            carOnRoad.RotateCar();
            carOnRoad._canMove = true;

            Vector3 directionZ = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 
            directionCar == 0 || directionCar == 1 ? (gameObject.transform.position.z - _distanceMove) : (gameObject.transform.position.z + _distanceMove));
            _sequence.Append(gameObject.transform.DOMove(directionZ, 10).SetSpeedBased().SetEase(Ease.Linear));
        }));

        _alreadyOnRoad = true;
    }

    public void MoveCarVecrtical(int directionCar)
    {
        _rb.angularVelocity = Vector3.zero;
        _rb.velocity = Vector3.zero;

        Vector3 directionZ = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 
        directionCar == 2 || directionCar == 3 ? (gameObject.transform.position.z - _distanceMove) : (gameObject.transform.position.z + _distanceMove));
        _sequence.Append(gameObject.transform.DOMove(directionZ, 10).SetSpeedBased().SetEase(Ease.Linear).OnComplete(() => 
        {
            carOnRoad.RotateCar();
            carOnRoad._canMove = true;

            Vector3 direction = new Vector3(directionCar == 0 || directionCar == 2 ? (gameObject.transform.position.x + _distanceMove) : (gameObject.transform.position.x - _distanceMove),
            gameObject.transform.position.y, gameObject.transform.position.z);
            _sequence.Append(gameObject.transform.DOMove(direction, 10).SetSpeedBased().SetEase(Ease.Linear));
        }));

        _alreadyOnRoad = true;
    }

    private void DefineCarSide(ref string sideRoad)
    {
        if(gameObject.CompareTag("CarHorizontal"))
        {
            if(_frontTrigger.activeInHierarchy)
            {
                if(sideRoad == "Right")
                    MoveCarHorizontal(1);
                else if(sideRoad == "Left")
                    MoveCarHorizontal(2);

                _backTrigger.SetActive(false);
            }
            else if(_backTrigger.activeInHierarchy)
            {
                if(sideRoad == "Right")
                    MoveCarHorizontal(3);
                else if(sideRoad == "Left")
                    MoveCarHorizontal(0);

                _frontTrigger.SetActive(false);
            }
        }
        else
        {
            if(_frontTrigger.activeInHierarchy)
            {
                if(sideRoad == "Up")
                    MoveCarVecrtical(0);
                else if(sideRoad == "Down")
                    MoveCarVecrtical(3);

                _backTrigger.SetActive(false);
            }
            else if(_backTrigger.activeInHierarchy)
            {
                if(sideRoad == "Up")
                    MoveCarVecrtical(1);
                else if(sideRoad == "Down")
                    MoveCarVecrtical(2);

                _frontTrigger.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!_alreadyOnRoad)
        {
            if(other.gameObject.CompareTag("Right"))
            {
                _directionTrigger = "Right";
                DefineCarSide(ref _directionTrigger);
            }
            else if(other.gameObject.CompareTag("Left"))
            {
                _directionTrigger = "Left";
                DefineCarSide(ref _directionTrigger);
            }
            else if(other.gameObject.CompareTag("Up"))
            {
                _directionTrigger = "Up";
                DefineCarSide(ref _directionTrigger);
            }
            else
            {
                _directionTrigger = "Down";
                DefineCarSide(ref _directionTrigger);
            }
        }
    }
}
