using System;
using UnityEngine;

public class ShipCollisionDetector : MonoBehaviour
{
    private Action<int> OnCollision;

    public void Initialize(Action<int> onCollision)
    {
        OnCollision = onCollision;
    }

    void OnTriggerEnter(Collider other)
    {
        IAsteroidCollider collider = other.gameObject.GetComponent<IAsteroidCollider>();
        if (collider != null)
        {
            OnCollision.Invoke(collider.Damage());
            collider.OnCollision();
        }
    }
}
