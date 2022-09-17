using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ParticleController : MonoBehaviour
{
    [SerializeField] private GameObject[] _particleObject;
    [SerializeField] private ParticleSystem[] _particleSystem;

    private int _currentTurnParticle;

    private bool _particleWillPlay = false;

    [Inject] DieScreen dieScreen;

    private void Update()
    {
        if(_particleWillPlay)
        {
            if(!_particleSystem[_currentTurnParticle].isPlaying)
            {
                dieScreen.ShowDieScreen();
            }
        }
    }

    public void CallParticleSystem(Vector3 positionSpawn)
    {
        for(int i = 0; i <= (_particleObject.Length - 1); i++)
        {
            if(_particleSystem[_currentTurnParticle].isPlaying)
            {
                _currentTurnParticle++;
                if(_currentTurnParticle > (_particleObject.Length - 1))
                {
                    _currentTurnParticle = 0;
                }
            }
            
        }
        
        _particleObject[_currentTurnParticle].transform.position = positionSpawn;
        _particleSystem[_currentTurnParticle].Play();

        if(!_particleWillPlay)
            Handheld.Vibrate();

        _particleWillPlay = true;
        
    }
}
