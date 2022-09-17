using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSound : MonoBehaviour
{
    [SerializeField] private AudioSource _musicTheme;
    [SerializeField] private AudioSource _coinFX;
    [SerializeField] private AudioSource _buttonPressFX;

    private void Start()
    {
        _musicTheme.Play();
    }

    public void ActiveCoinSound()
    {
        _coinFX.Play();
    }

    public void ButtonPressSound()
    {
        _buttonPressFX.Play();
    }
}
