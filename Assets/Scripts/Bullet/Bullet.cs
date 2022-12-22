using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletData bulletData;
    private Vector3 startPosition;
    private Rigidbody _rb;
    [SerializeField] internal float maxDistance, bulletSpeed, conquaredDistance;
    private void Awake()
    {
        
        _rb = GetComponent<Rigidbody>();
        Debug.Log("Current Bullet speed is :" + bulletSpeed);
    }
   

    private void Update()
    {
        conquaredDistance = Vector3.Distance(transform.position, startPosition);
        if(conquaredDistance > maxDistance)
        {
            DisableObject();
        }
      
    }

    internal void DisableObject()
    {
        _rb.velocity = Vector3.zero;
        this.gameObject.SetActive(false);
    }
   
    public void Inýtialize()
    {

        startPosition = transform.position;
        _rb.velocity = transform.forward *this.bulletSpeed;
    }

  

}
