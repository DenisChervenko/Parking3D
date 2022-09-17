using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollectLogic : MonoBehaviour
{
    [Header("GameObject")]
    [SerializeField] private GameObject _coin;
    [SerializeField] private GameObject _gem;

    [Header("Particle")]
    [SerializeField] private ParticleSystem _particleCoin;
    [SerializeField] private ParticleSystem _particleGem;

    [Header("Balance Text")]
    [SerializeField] private TMP_Text _coinBalancePlayerText;
    [SerializeField] private TMP_Text _gemBalancePlayerText;

    [Header("Reward")]
    [SerializeField] private int _rewardForOneGem;
    [SerializeField] private int _rewardForOneCoin;

    private int _coinBalancePlayer;
    private int _gemBalancePlayer;

    private bool _gemOnCar = false;

    private Animator _animatorCoin;
    private Animator _animatorGem;
    private MeshRenderer _coinMeshRenderer;
    private MeshRenderer _gemMeshRenderer;

    private void Start()
    {
        _animatorCoin = _coin.GetComponent<Animator>();
        _animatorGem = _gem.GetComponent<Animator>();

        _coinMeshRenderer = _coin.GetComponent<MeshRenderer>();
        _gemMeshRenderer = _gem.GetComponent<MeshRenderer>();

        _gemMeshRenderer.enabled = false;
        _coinMeshRenderer.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Gem"))
        {
            _gemOnCar = true;
            _gemMeshRenderer.enabled = true;

            _animatorGem.SetTrigger("GemIdle");
        }

        if(!_gemOnCar)
        {
            if(other.gameObject.CompareTag("CarVertical") || other.gameObject.CompareTag("CarHorizontal"))
            {
                _coinMeshRenderer.enabled = true;

                _animatorCoin.SetTrigger("CoinIdle");
            }
        } 
    }

    public void CoinParticleEventAnimation()
    {
        _particleCoin.Play();
    }
    public void GemParticleEventAnimation()
    {
        _gemOnCar = false;
        _particleGem.Play();
    }

    public void CoinAddBalanceEventAnimation()
    {
        _coinBalancePlayer += _rewardForOneCoin;
        _coinBalancePlayerText.text = Convert.ToString(_coinBalancePlayer);

        _coinMeshRenderer.enabled = false;

        _animatorCoin.SetTrigger("DefaultState");
    }
    public void GemAddBalanceEventAnimation()
    {
        _gemBalancePlayer += _rewardForOneGem;
        _gemBalancePlayerText.text = Convert.ToString(_gemBalancePlayer);

        _gemMeshRenderer.enabled = false;

        _animatorGem.SetTrigger("DefaultState");
    }
}
