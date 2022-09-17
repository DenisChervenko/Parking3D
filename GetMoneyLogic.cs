using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GetMoneyLogic : MonoBehaviour
{
    [SerializeField] private bool _isCoin;
    [SerializeField] private int _reward;

    [SerializeField] private GameObject _parentMoney;
    [SerializeField] private GameObject _money;
    [SerializeField] private ParticleSystem _particleReward;

    [Inject] private AddBalance addBalance;

    private Animator _animator;
    private MeshRenderer _moneyMeshRenderer;

    private void Start()
    {
        _animator = _money.GetComponent<Animator>();
        _moneyMeshRenderer = _money.GetComponent<MeshRenderer>();

        _moneyMeshRenderer.enabled = false;
    }

    private void GetMoney()
    {
        _moneyMeshRenderer.enabled = _isCoin == true ? true : false;
        _parentMoney.transform.SetParent(null);

        _animator.SetTrigger("Idle");
        _particleReward.Play();

        addBalance.AddPlayerBalance(_isCoin, _reward);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("MoneyZone"))
        {
            GetMoney();
        }
    }

    public void EventAnimationEnd()
    {
        _parentMoney.SetActive(false);
    }
}
