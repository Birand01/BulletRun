using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpButton : MonoBehaviour
{
    public delegate void SpeedUpHandler();
    public static event SpeedUpHandler OnSpeedUpHandler; 
    public void SpeedUpEventButton()
    {
        OnSpeedUpHandler?.Invoke();
    }
}
