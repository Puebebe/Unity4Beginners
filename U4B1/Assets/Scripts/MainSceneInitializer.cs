using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MainSceneInitializer : MonoBehaviour
{
    [SerializeField] float shipSpeed;
    [SerializeField] float asteroidSpeed;
    [SerializeField] GameObject asteroidPrefab;

    [SerializeField] MovingComponent ship;
    [FormerlySerializedAs("rocks")]
    [SerializeField] List<MovingComponent> asteroids;

    private void Awake()
    {
        ship.Initialize(shipSpeed, new InputAdapter());

        for (int i = 0; i < asteroids.Count; i++)
        {
            asteroids[i].Initialize(asteroidSpeed, new LeftInputAdapter());
        }
    }
}
