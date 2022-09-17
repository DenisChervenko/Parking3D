using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSideTriggerDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Up") == true || other.gameObject.CompareTag("Down") == true ||
        other.gameObject.CompareTag("Left") == true || other.gameObject.CompareTag("Right") == true)
        {
            gameObject.SetActive(false);
        }
    }
}
