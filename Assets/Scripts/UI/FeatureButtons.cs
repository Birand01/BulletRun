using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class FeatureButtons : MonoBehaviour
{
   
    [SerializeField] private List<Button> featurebuttons = new List<Button>();

    private void Start()
    {
        foreach (Button button in featurebuttons)
        {
            button.onClick.AddListener(OnClickEvent);
        }
    }

    private void OnClickEvent()
    {
       
    }
}
