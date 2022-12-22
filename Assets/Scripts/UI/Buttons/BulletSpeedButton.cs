using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpeedButton : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private BulletData bulletData;

    public void BulletSpeedUp()
    {

        bullet.bulletSpeed = bulletData.speed;
        this.enabled = false;
        Debug.Log("New Bullet speed is :" + bulletData.speed);
    }
}
