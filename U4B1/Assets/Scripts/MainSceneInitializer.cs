using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MainSceneInitializer : MonoBehaviour
{
    [SerializeField] float shipSpeed;
    [Header("Asteroid Variables")]
    [SerializeField] float asteroidSpeedMin;
    [SerializeField] float asteroidSpeedMax;
    [SerializeField] float asteroidSpawnPointX;
    [SerializeField] float asteroidSpawnPointY;
    [SerializeField] GameObject asteroidPrefab;
    [SerializeField] AsteroidCreator asteroidCreator;

    [Header("Scene References")]
    [SerializeField] MovingComponent ship;

    private void Awake()
    {
        asteroidCreator.Intialize(asteroidSpeedMin, asteroidSpeedMax, asteroidSpawnPointX, asteroidSpawnPointY, asteroidPrefab);

        ship.Initialize(shipSpeed, new InputAdapter());

        
    }
}
