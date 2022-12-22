using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadDelayButton : MonoBehaviour
{
    [SerializeField] private Gun gun;
    [SerializeField] private GunData gunData;

    public void ChangeReloadDelay()
    {
        gun.reloadDelay = gunData.reloadDelay;
        Debug.Log("New Reload Delay is :" +gunData.reloadDelay);
    }
}
