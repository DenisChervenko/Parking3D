using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleController : MonoBehaviour
{
    private void Awake()
    {
        TimeResume();
    }

    public void TimeStop()
    {
        Time.timeScale = 0;
    }

    public void TimeResume()
    {
        Time.timeScale = 1;
    }
}
