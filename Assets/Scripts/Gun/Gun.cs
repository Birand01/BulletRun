using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectPool))]
public class Gun : Singleton<Gun>
{

    private ObjectPool bulletPool;
    [SerializeField] private int bulletPoolCount = 10;
    [SerializeField] internal float reloadDelay;
    [SerializeField] private GameObject bulletPrefab;
    public List<Transform> gunBarrels;

    private float currentDelay = 0;
    internal bool canShoot = true;
    protected override void Awake()
    {

        bulletPool = GetComponent<ObjectPool>();
        Debug.Log("Current reload delay is :" +reloadDelay);
    }
    private void Start()
    {
        bulletPool.Inýtýalize(bulletPrefab, bulletPoolCount);
    }
    private void OnEnable()
    {
        PlayerInput.OnPlayerInput+= Shoot;
    }
    private void Update()
    {
        CanShoot();
    }
    private void CanShoot()
    {
        if (canShoot == false)
        {
            currentDelay -= Time.deltaTime;
            if (currentDelay <= 0 && !PlayerController.GetInstance().isLevelFail)
            {
                canShoot = true;
            }
        }
    }
    public void Shoot(bool state)
    {
       
        if(canShoot && state)
        {
            canShoot=false;
            currentDelay = reloadDelay;
            foreach (var barrel in gunBarrels)
            {
                //GameObject bullet = Instantiate(bulletPrefab);
                GameObject bullet = bulletPool.CreateObject();
                bullet.transform.position = barrel.position;
                bullet.transform.localRotation = barrel.rotation;
                bullet.GetComponent<Bullet>().Inýtialize();
            }
        }
    }
  
    private void OnDisable()
    {
        PlayerInput.OnPlayerInput -= Shoot;
    }

}
