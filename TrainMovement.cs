using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _distance;

    private void Update()
    {
        gameObject.transform.position = new Vector3(Mathf.Repeat(Time.time * _speed, _distance), transform.position.y, transform.position.z);
    }
}
