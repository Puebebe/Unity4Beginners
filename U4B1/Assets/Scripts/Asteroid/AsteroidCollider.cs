using System;
using UnityEngine;

public class AsteroidCollider : MonoBehaviour, IAsteroidCollider
{
    private Action<GameObject> callback;

    public int Damage()
    {
        return 1;
    }

    public void SetCollisionCallBack(Action<GameObject> callback)
    {
        this.callback = callback;
    }

    public void OnCollision()
    {
        callback.Invoke(gameObject);
    }
}
