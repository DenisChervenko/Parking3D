using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Zenject;

public class CarMerge : MonoBehaviour
{
    private BoxCollider _boxCollider;
    private Rigidbody _rb;
    private Animator _anim;

    [Inject] ParticleController particleController;

    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
        _boxCollider = gameObject.GetComponent<BoxCollider>();
        _anim = gameObject.GetComponent<Animator>();
    }

    private void CarDestroy()
    {
        _anim.SetTrigger("Destroy");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!_rb.isKinematic)
        {
            if(other.gameObject.CompareTag("CarVertical") || other.gameObject.CompareTag("CarHorizontal"))
            {
                _boxCollider.enabled = false;
                
                particleController.CallParticleSystem(gameObject.transform.position);
                CarDestroy();
            }
        }
    }
}
