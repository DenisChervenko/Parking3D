using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Zenject;

public class CarOnRoad : MonoBehaviour
{
    [SerializeField] private Transform[] _pointForFollow;

    [SerializeField] private float _speedMove;
    [SerializeField] private float _speedRotate;

    private int _currentTurnForFollowPoint = 11;

    [HideInInspector]
    public bool _canMove = false;
    public bool _canRotate = false;

    private Animator _anim;
    private BoxCollider _boxCollider;
    private Rigidbody _rb;

    [Inject] CarController carController;

    private void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
        _rb = gameObject.GetComponent<Rigidbody>();
        _boxCollider = gameObject.GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if(_canMove)
        {
            Vector3 movement = gameObject.transform.position;
            movement = Vector3.MoveTowards(gameObject.transform.position, _pointForFollow[_currentTurnForFollowPoint].position, _speedMove * Time.deltaTime);
            _rb.MovePosition(movement);

            if(_canRotate)
            {
                RotateCar();
            }

            if(Vector3.Distance(gameObject.transform.position, _pointForFollow[_currentTurnForFollowPoint].position) < 0.1f)
            {
                _currentTurnForFollowPoint++;
                _canRotate = true;
            }
        }
    }

    public void RotateCar()
    {
        gameObject.transform.DOLookAt(
            _pointForFollow[_currentTurnForFollowPoint].position, 0.09f, AxisConstraint.Y, Vector3.up).SetEase(Ease.Linear).OnComplete(() => _canRotate = false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!_rb.isKinematic)
        {   
            if(other.gameObject.CompareTag("Finish"))
            {
                gameObject.SetActive(false);
            }

            if(_currentTurnForFollowPoint > 3)
            {
                if(other.gameObject.CompareTag("Up"))
                    _currentTurnForFollowPoint = 0;
                else if(other.gameObject.CompareTag("Right"))
                    _currentTurnForFollowPoint = 1; 
                else if(other.gameObject.CompareTag("Down"))
                    _currentTurnForFollowPoint = 2;
                else if(other.gameObject.CompareTag("Left"))
                    _currentTurnForFollowPoint = 3;

                _anim.SetTrigger("Move");

                _boxCollider.isTrigger = true;
                carController._currentRigidbody.isKinematic = false;
                carController._currentRigidbody = null;
            }
            
            if(_currentTurnForFollowPoint < 4)
            {
                _rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
            }
        }
        
    }
}
