using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ParkingTrigger : MonoBehaviour
{
    [SerializeField] private bool _isParkingTriggerInside;
    [Inject] private BarrierPass barrierPass;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("CarVertical") || other.gameObject.CompareTag("CarHorizontal"))
        {
            barrierPass.CarPassController(_isParkingTriggerInside);
        }
    }
}
