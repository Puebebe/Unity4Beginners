using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAsteroidCollider
{
    int Damage();
    void SetCollisionCallBack(Action<GameObject> callback);
    void OnCollision();
}
