using System.Collections;
using UnityEngine;

public class AsteroidCreator : MonoBehaviour
{
    private float spawnDelay;
    private float timer = 0;
    private float minSpeed;
    private float maxSpeed;
    private float spawnPointX;
    private float spawnPointY;
    private IInput input;
    private IPrefabPool pool;

    public void Intialize(float minSpeed, float maxSpeed, float spawnPointX, float spawnPointY, float spawnDelay, IPrefabPool pool)
    {
        this.minSpeed = minSpeed;
        this.maxSpeed = maxSpeed;
        this.spawnPointX = spawnPointX;
        this.spawnPointY = spawnPointY;
        this.spawnDelay = spawnDelay;
        this.pool = pool;
    }

    private void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
        else
        {
            InitializeAsteroid();
            timer = spawnDelay;
        }
    }

    public void InitializeAsteroid()
    {
        GameObject asteroid = pool.Get();
        asteroid.transform.position = new Vector3(spawnPointX, RandomYPosition());
        asteroid.transform.parent = transform;

        MovingComponent moving = asteroid.GetComponent<MovingComponent>();
        moving.Initialize(RandomSpeed(), new LeftInputAdapter());
        moving.StartCoroutine(WaitForDestruction(asteroid));

        IAsteroidCollider asteroidCollider = asteroid.GetComponent<IAsteroidCollider>();
        asteroidCollider.SetCollisionCallBack(ReturnToPool);
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

        ReturnToPool(asteroid);
    }

    private void ReturnToPool(GameObject asteroid)
    {
        pool.Return(asteroid);
    }
}
