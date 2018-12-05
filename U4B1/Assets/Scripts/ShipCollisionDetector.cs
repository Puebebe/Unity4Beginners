using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollisionDetector : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        IAsteroidCollider collider = other.gameObject.GetComponent<IAsteroidCollider>();
        if (collider != null)
        {
            collider.Damage();
            Destroy(other.gameObject);
        }
    }
}
