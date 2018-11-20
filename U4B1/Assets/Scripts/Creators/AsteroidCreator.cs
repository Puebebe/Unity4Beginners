using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCreator
{
    private float minSpeed;
    private float maxSpeed;
    private float spawnPointX;
    private float spawnPointY;
    private IInput input;
    private GameObject asteroidPrefab;

    public AsteroidCreator(float minSpeed, float maxSpeed, float spawnPointX, float spawnPointY, IInput input, GameObject asteroidPrefab)
    {
        this.minSpeed = minSpeed;
        this.maxSpeed = maxSpeed;
        this.spawnPointX = spawnPointX;
        this.spawnPointY = spawnPointY; 
        this.input = input;
        this.asteroidPrefab = asteroidPrefab;
    }

    public GameObject CreateAsteroid()
    {
        GameObject asteroid = GameObject.Instantiate(asteroidPrefab, new Vector3(spawnPointX, RandomYPosition()), Quaternion.identity);
        asteroid.GetComponent<MovingComponent>().StartCoroutine(WaitForDestruction(asteroid));
        return asteroid;
    }

    private float RandomYPosition()
    {
        return Random.Range(-spawnPointY, spawnPointY);
    }

    private IEnumerator WaitForDestruction(GameObject asteroid)
    {
        while (asteroid.transform.position.x >= -spawnPointX)
        {
            yield return null;
        }
        GameObject.Destroy(asteroid);
    }
}
