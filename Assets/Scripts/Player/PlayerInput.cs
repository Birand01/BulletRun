using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public delegate void OnPlayerInputHandler(bool state);
    public static event OnPlayerInputHandler OnPlayerInput;

    public delegate void OnPlayerBodyMovementHandler(Ray point);
    public static event OnPlayerBodyMovementHandler OnPlayerBodyMovement;


    private void Update()
    {
        OnGameStart();
        OnGameStop();
        OnBodyMovement();

    }

    private void OnGameStart()
    {
        if (Input.GetMouseButton(0) && Gun.GetInstance().canShoot)
        {
            OnPlayerInput?.Invoke(true);
        }
    }
    private void OnGameStop()
    {
        if(Input.GetMouseButtonUp(0))
        {
            OnPlayerInput?.Invoke(false);
        }
    }

    private void OnBodyMovement()
    {
        OnPlayerBodyMovement?.Invoke(GetMousePosition());
    }

    private Ray GetMousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        Ray mouseWorldPos = Camera.main.ScreenPointToRay(mousePos);
        return mouseWorldPos;
    }
}
