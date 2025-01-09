using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="NewEnemyData", menuName = "ScriptableObject/Enemy")]
public class EnemyData : ScriptableObject
{
    public new string name;
    public float HP;
    public float Speed;
    public float dame;
}
