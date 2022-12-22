using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : UniversalAnimation
{
   

    private void OnEnable()
    {
        PlayerInput.OnPlayerInput += ShootAnimation;
        PlayerCollisionWithEnemy.OnPlayerFail += TerrifiedAnimation;
       
    
    }

   
    private void OnDisable()
    {
        PlayerInput.OnPlayerInput -= ShootAnimation;
        PlayerCollisionWithEnemy.OnPlayerFail -= TerrifiedAnimation;
       

    }
}
