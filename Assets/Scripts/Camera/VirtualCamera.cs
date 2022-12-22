using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class VirtualCamera : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCamera;
    private CinemachineTransposer transposer;
    CinemachineComposer composer;

    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        composer = virtualCamera.GetCinemachineComponent<CinemachineComposer>();

    }
    private void OnEnable()
    {
        PlayerCollisionWithEnemy.OnGameFailCameraAngle += LevelFailCameraPosition;
    }

    private void LevelFailCameraPosition()
    {
        transposer.m_FollowOffset = new Vector3(25, 20, 0);
        TransposerDampingAdjustment();
        composer.m_TrackedObjectOffset = new Vector3(0, 7, 0);
    }

    private void TransposerDampingAdjustment()
    {
        transposer.m_XDamping = 5;
        transposer.m_YDamping = 5;
        transposer.m_ZDamping = 5;
    }
    private void OnDisable()
    {
        PlayerCollisionWithEnemy.OnGameFailCameraAngle -= LevelFailCameraPosition;
    }
}
