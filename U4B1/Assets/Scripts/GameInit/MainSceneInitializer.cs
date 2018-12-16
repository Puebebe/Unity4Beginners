using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;

public class MainSceneInitializer : MonoBehaviour
{
    [Header("Ship variables")]
    [SerializeField] int shipMaxLife;
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
    [SerializeField] List<GameObject> ship;

    [Header("UI")]
    [SerializeField] Image lifeBar;
    [SerializeField] GameObject gameEndingObject;
    [SerializeField] float gameEndingDelay;

    void Awake()
    {
        IPrefabPool asteroidPool = new PrefabPool(asteroidPoolSize, asteroidPrefab);
        asteroidCreator.Intialize(asteroidSpeedMin, asteroidSpeedMax, asteroidSpawnPointX, asteroidSpawnPointY, asteroidSpawnDelay, asteroidPool);

        for (int i = 0; i < ship.Count; i++)
        {
            IGameEnding gameEnding = new GameEnding(ship[i], this, gameEndingObject, gameEndingDelay);

            LifeManager lifeManager = gameObject.AddComponent<LifeManager>();
            lifeManager.Initialize(lifeBar, shipMaxLife, ship[i], gameEnding);
            ship[i].GetComponent<ShipCollisionDetector>().Initialize(lifeManager.DealDamage);

            ship[i].GetComponent<MovingComponent>().Initialize(shipSpeed, new InputAdapter());
        }
    }
}
