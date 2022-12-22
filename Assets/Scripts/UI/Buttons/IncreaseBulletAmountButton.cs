using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseBulletAmountButton : MonoBehaviour
{
    [SerializeField] Transform barrel2,barrel3;
    [SerializeField] private Gun gun;

    public void TripleBulletAmount()
    {
        gun.gunBarrels.Add(barrel2);
        gun.gunBarrels.Add(barrel3);
       
    }
}
