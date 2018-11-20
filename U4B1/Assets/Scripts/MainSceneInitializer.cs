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

    [Header("Scene References")]
    [SerializeField] MovingComponent ship;
    [FormerlySerializedAs("rocks")]
    [SerializeField] List<MovingComponent> asteroids;

    private AsteroidCreator asteroidCreator;

    private void Awake()
    {
        asteroidCreator = new AsteroidCreator(asteroidSpeedMin, asteroidSpeedMax, asteroidSpawnPointX, asteroidSpawnPointY, new LeftInputAdapter(), asteroidPrefab);

        ship.Initialize(shipSpeed, new InputAdapter());

        
    }
}
