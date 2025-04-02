﻿using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Arrow : Bullet
{   
    protected override void OnEnable()
    {
        base.OnEnable();
        speed = 70;
        distanceMax = 4;
    }

    // ham di chuyen vien đạn
    public override void Move(Vector2 direction)
    {
        this.rbBullet.AddForce(direction * speed * Time.deltaTime, ForceMode2D.Impulse);
    }

    public override void CheckDistance(int distanceMax)
    {
        base.CheckDistance(distanceMax);    
    }

}
