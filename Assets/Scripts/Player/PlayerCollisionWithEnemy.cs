using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionWithEnemy : UniversalCollision
{
    public delegate void OnFailEventHandler(bool state);
    public delegate void OnGameFailCameraAngleHandler();
    public delegate void OnPlayerRagdollHandler();


    public static event OnGameFailCameraAngleHandler OnGameFailCameraAngle;
    public static event OnFailEventHandler OnPlayerFail;
    public static event OnPlayerRagdollHandler OnPlayerRagdoll;


    protected override void OnTriggerAction(Collider collider)
    {
        OnPlayerFail?.Invoke(true);
        OnPlayerRagdoll?.Invoke();
        OnGameFailCameraAngle?.Invoke();
        collider.gameObject.GetComponent<EnemyAnimation>().IdleComboAnimation();
        LookAtEnemy(collider);
        collider.gameObject.transform.LookAt(transform.position);
    }
    private void LookAtEnemy(Collider enemy)
    {
        transform.LookAt(enemy.transform);
    }
}
