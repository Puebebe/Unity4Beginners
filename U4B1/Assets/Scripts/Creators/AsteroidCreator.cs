using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCreator : MonoBehaviour
{
    private float minSpeed;
    private float maxSpeed;
    private float spawnPointX;
    private float spawnPointY;
    private IInput input;
    private GameObject asteroidPrefab;

    public void Intialize(float minSpeed, float maxSpeed, float spawnPointX, float spawnPointY, GameObject asteroidPrefab)
    {
        this.minSpeed = minSpeed;
        this.maxSpeed = maxSpeed;
        this.spawnPointX = spawnPointX;
        this.spawnPointY = spawnPointY;
        this.asteroidPrefab = asteroidPrefab;
    }

    private void Update()
    {
        CreateAsteroid();
    }

    public void CreateAsteroid()
    {
        GameObject asteroid = Instantiate(asteroidPrefab, new Vector3(spawnPointX, RandomYPosition()), asteroidPrefab.transform.rotation, transform);
        MovingComponent moving = asteroid.GetComponent<MovingComponent>();
        moving.Initialize(RandomSpeed(), new LeftInputAdapter());
        moving.StartCoroutine(WaitForDestruction(asteroid));
    }

    private float RandomSpeed()
    {
        return Random.Range(minSpeed, maxSpeed);
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
