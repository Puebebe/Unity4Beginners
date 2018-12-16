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
    [SerializeField] float asteroidSpawnDelay;
    [SerializeField] GameObject asteroidPrefab;
    [SerializeField] AsteroidCreator asteroidCreator;
    [SerializeField] int asteroidPoolSize;

    [Header("Scene References")]
    [SerializeField] MovingComponent ship;

    private void Awake()
    {
        PrefabPool asteroidPool = new PrefabPool(asteroidPoolSize, asteroidPrefab);
        asteroidCreator.Intialize(asteroidSpeedMin, asteroidSpeedMax, asteroidSpawnPointX, asteroidSpawnPointY, asteroidSpawnDelay, asteroidPool);
        ship.Initialize(shipSpeed, new InputAdapter());
    }
}
