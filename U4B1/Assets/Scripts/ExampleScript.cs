using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleScript : MonoBehaviour
{
	// Use this for initialization
	void Start () {
        Debug.Log(gameObject.name);
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("shouldn't be seen, becouse of disabled script");
	}
}
