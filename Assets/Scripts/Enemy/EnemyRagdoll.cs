using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRagdoll : UniversalRagdoll
{
    [SerializeField] private float enemyRagdollTime;

   
    protected override void Awake()
    {
        ragdollEnabilityTime = enemyRagdollTime;
        base.Awake();
    }
   
}
