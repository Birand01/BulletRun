using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text levelFailText;
        
    private void OnEnable()
    {
        PlayerCollisionWithEnemy.OnGameFailCameraAngle += LevelFailTextVisibility;
    }

    private void OnDisable()
    {
        PlayerCollisionWithEnemy.OnGameFailCameraAngle -= LevelFailTextVisibility;
    }
    private IEnumerator ReLoadCurrentLevel()
    {
        yield return new WaitForSeconds(7.0f);
        SceneManager.LoadScene(0);
    }
        
    private void LevelFailTextVisibility()
    {
        levelFailText.gameObject.SetActive(true);
        StartCoroutine(ReLoadCurrentLevel());
    }



}
