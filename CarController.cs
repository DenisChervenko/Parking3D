using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;

    [SerializeField] private float _speedMove;

    [HideInInspector]
    public Rigidbody _currentRigidbody;

    private bool _willTouch = false;

    private float _currentSpeedObject;

    private float _directionX;
    private float _directionY;

    private Vector2 _startTouchPosition;
    private Vector2 _endTouchPosition;

    private Camera _camera;

    RaycastHit _hit;
    Ray _ray;


    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);
 
            if(Physics.Raycast(_ray, out _hit, 300, _layerMask))
            {
                if(!_willTouch)
                {
                    _currentRigidbody = _hit.rigidbody;

                    _startTouchPosition = Input.mousePosition;

                    _willTouch = true;
                }

                if(_currentRigidbody != null)
                {
                    _currentRigidbody.isKinematic = false;

                    _endTouchPosition = Input.mousePosition;

                    _directionX = _endTouchPosition.x - _startTouchPosition.x;
                    _directionY = _endTouchPosition.y - _startTouchPosition.y;

                    MoveCar();
                }
            }
        }

        if(_currentRigidbody != null)
        {
            DefineCarVelocity();
        }
        
        if(Input.GetMouseButtonUp(0))
        {
            if(_willTouch)
            {
                _willTouch = false;
            }
        }
    }

    private void DefineCarVelocity()
    {
        _currentSpeedObject = _currentRigidbody.velocity.magnitude * 3.6f;

        if(_currentRigidbody.velocity == Vector3.zero || _currentSpeedObject < 15f)
            _currentRigidbody.isKinematic = true;
    }

    private void MoveCar()
    {
        if(Mathf.Abs(_directionX) > Mathf.Abs(_directionY))
        {
            _currentRigidbody.velocity = new Vector3((_directionX > 0.25f ? _speedMove : -_speedMove), 0, 0);
        }
        else if(Mathf.Abs(_directionX) < Mathf.Abs(_directionY))
        {
            _currentRigidbody.velocity = new Vector3(0, 0, (_directionY > 0.25f ? _speedMove : -_speedMove));
        }
    }
}
