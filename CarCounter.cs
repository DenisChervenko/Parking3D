using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _carCountCollectText;
    private int _carCountCollect;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("CarVertical") || other.gameObject.CompareTag("CarHorizontal"))
        {
            _carCountCollect += 1;
            _carCountCollectText.text = Convert.ToString(_carCountCollect);
        }
    }
}
