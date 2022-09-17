using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("MoneyZone"))
        {
            gameObject.SetActive(false);
        }
    }
}
