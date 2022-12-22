using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    [SerializeField] private PlayerSpeedData speedData;


    [HideInInspector] public bool IsGameStart = false;
    internal bool isLevelFail = false;
    private bool isLevelEnd = false;
    [SerializeField] public Vector2 clampValuesX = new Vector2(-4.5f, +4.5f);
    private Vector3 mouseStartPos, PlayerStartPos;
    public float currentSpeed, swipeSpeed;
    protected virtual void OnEnable()
    {
        PlayerInput.OnPlayerBodyMovement += MovePlayer;
        PlayerInput.OnPlayerInput += GameState;
        PlayerCollisionWithEnemy.OnPlayerFail += IsLevelFail;
        SpeedUpButton.OnSpeedUpHandler += SpeedUp;
      //  LevelManager.OnLevelFail += IsLevelFail;
       // LevelManager.OnLevelEnd += IsLevelEnd;

    }

    private void GameState(bool state)
    {
        IsGameStart = state;
    }
    private void IsLevelFail(bool state)
    {
        isLevelFail = state;
    }
    private void IsLevelEnd(bool state)
    {
        isLevelEnd = state;
    }


    protected virtual void MovePlayer(Ray pointerPosition)
    {
        if (IsGameStart && !isLevelFail && !isLevelEnd)
        {
            var plane = new Plane(Vector3.up, 0.0f);
            float distance;

            if (plane.Raycast(pointerPosition, out distance))
            {
                Vector3 mousePos = pointerPosition.GetPoint(distance);
                Vector3 desiredPos = mousePos - mouseStartPos;
                Vector3 move = PlayerStartPos + desiredPos;
                move.x = Mathf.Clamp(move.x, clampValuesX.x, clampValuesX.y);
                move.z = -7.0f;
                Vector3 player = transform.position;
                player = new Vector3(Mathf.Lerp(player.x, move.x, Time.deltaTime * swipeSpeed), player.y, player.z);
                transform.position = player;
                transform.Translate(Vector3.forward * Time.deltaTime * currentSpeed);
            }
        }

    }
    private void SpeedUp()
    {
        currentSpeed = speedData.playerSpeed;
    }
  

    protected virtual void OnDisable()
    {
      //  LevelManager.OnLevelFail -= IsLevelFail;
        PlayerInput.OnPlayerInput -= GameState;
        PlayerInput.OnPlayerBodyMovement -= MovePlayer;
        PlayerCollisionWithEnemy.OnPlayerFail -= IsLevelFail;
        SpeedUpButton.OnSpeedUpHandler -= SpeedUp;
    }
}
