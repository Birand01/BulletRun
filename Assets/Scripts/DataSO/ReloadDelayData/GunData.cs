using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GunData", menuName = "Data/GunData")]
public class GunData : ScriptableObject
{
    public GameObject bulletPrefab;
    public float reloadDelay;
    //public BulletData bulletData;
}
