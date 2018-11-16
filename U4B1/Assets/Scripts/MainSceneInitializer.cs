using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MainSceneInitializer : MonoBehaviour
{
    [SerializeField] float shipSpeed;
    [SerializeField] float asteroidSpeed;

    [SerializeField] List<MovingComponent> ships;
    [SerializeField] List<MovingComponent> rocks;

    private void Awake()
    {
        for (int i = 0; i < ships.Count; i++)
        {
            ships[i].Initialize(shipSpeed, new InputAdapter());
        }

        for (int i = 0; i < rocks.Count; i++)
        {
            rocks[i].Initialize(asteroidSpeed, new LeftInputAdapter());
        }
    }
}
