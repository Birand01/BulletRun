using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionWithEnemy : UniversalCollision
{
   

    protected override void OnTriggerAction(Collider collider)
    {
       
        Debug.Log("Collider name : " + collider.name);
        // DisableObject();
        collider.gameObject.GetComponent<EnemyAnimation>().DisableAnimation();
        collider.gameObject.GetComponent<EnemyRagdoll>().EnableRagdoll();
       
    }

    
}
