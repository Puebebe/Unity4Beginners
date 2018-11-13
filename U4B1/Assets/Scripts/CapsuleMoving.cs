using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleMoving : MonoBehaviour
{
    [SerializeField] float shipSpeedPerSecond;

    Transform myTransform;
    //[SerializeField] ExampleScript exampleScript;

    private void Start()
    {
        myTransform = transform;
        //exampleScript = gameObject.GetComponent<ExampleScript>();
        //exampleScript.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
            UpdatePosition(Vector3.up);

        if (Input.GetKey(KeyCode.S))
            UpdatePosition(Vector3.down);

        if (Input.GetKey(KeyCode.A))
            UpdatePosition(Vector3.left);

        if (Input.GetKey(KeyCode.D))
            UpdatePosition(Vector3.right);

    }

    private void UpdatePosition(Vector3 moveVector)
    {
        myTransform.position += moveVector * shipSpeedPerSecond * Time.deltaTime;
    }
}
