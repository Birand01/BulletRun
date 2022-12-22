using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRagdoll : UniversalRagdoll
{
   

    [SerializeField] private float playerRagdollTime;
    private void OnEnable()
    {
        PlayerCollisionWithEnemy.OnPlayerRagdoll += EnableRagdoll;
    }
    private void OnDisable()
    {
        PlayerCollisionWithEnemy.OnPlayerRagdoll -= EnableRagdoll;
    }
    protected override void Awake()
    {
        ragdollEnabilityTime = playerRagdollTime;
        base.Awake();
    }

    public override IEnumerator EnableRagdollCoroutine()
    {
        return base.EnableRagdollCoroutine();
       
    }



}
