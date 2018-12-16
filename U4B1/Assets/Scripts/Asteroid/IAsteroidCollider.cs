using System;
using UnityEngine;

public interface IAsteroidCollider
{
    int Damage();
    void SetCollisionCallBack(Action<GameObject> callback);
    void OnCollision();
}
