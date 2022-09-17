using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelecter : MonoBehaviour
{  
    [SerializeField] private GameObject[] _car;

    private int _carrWasSelected;

    private void Start()
    {
        if(PlayerPrefs.HasKey("WasSelected"))
        {
            _carrWasSelected = PlayerPrefs.GetInt("WasSelected");
        }

        _car[_carrWasSelected].SetActive(true);
    }
}
