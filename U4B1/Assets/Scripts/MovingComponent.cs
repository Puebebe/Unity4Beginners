using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingComponent : MonoBehaviour
{
    [SerializeField] float shipSpeedPerSecond;
    private IInput input;

    Transform myTransform;
    [SerializeField] ExampleScript exampleScript;

    private void Start()
    {
        myTransform = transform;
        //exampleScript = gameObject.GetComponent<ExampleScript>();
        exampleScript.enabled = false;
    }

    public void Initialize(float speed, IInput inputAdapter)
    {
        input = inputAdapter;
        shipSpeedPerSecond = speed;
    }

    private void Update()
    {
        if (input.GetKey("w"))
            UpdatePosition(Vector3.up);

        if (input.GetKey("s"))
            UpdatePosition(Vector3.down);

        if (input.GetKey("a"))
            UpdatePosition(Vector3.left);

        if (input.GetKey("d"))
            UpdatePosition(Vector3.right);

    }
    private void UpdatePosition(Vector3 moveVector)
    {
        myTransform.position += moveVector * shipSpeedPerSecond * Time.deltaTime;
    }
    /*
    private void UpdatePosition(string key, Vector3 moveVector)
    {
        if (Input.GetKey(key))
            myTransform.position += moveVector * shipSpeedPerSecond * Time.deltaTime;
    }
    */
}
