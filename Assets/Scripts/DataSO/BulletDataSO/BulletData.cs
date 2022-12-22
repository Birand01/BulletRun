using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="BulletData",menuName ="Data/BulletData")]
public class BulletData : ScriptableObject
{
    public float speed;
    public int damage;
    public float maxDistance;
    
}
