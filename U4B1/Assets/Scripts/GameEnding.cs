using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : IGameEnding
{
    private GameObject ship;
    private MainSceneInitializer coroutineRunner;
    private GameObject gameOverObject;
    private float endGameDelay;

    public GameEnding(GameObject ship, MainSceneInitializer coroutineRunner, GameObject gameOverObject, float endGameDelay)
    {
        this.ship = ship;
        this.coroutineRunner = coroutineRunner;
        this.gameOverObject = gameOverObject;
        this.endGameDelay = endGameDelay;
    }

    public void EndGame()
    {
        gameOverObject.SetActive(true);
        UnityEngine.Object.Destroy(ship);
        coroutineRunner.StartCoroutine(DelayDisplay());
    }

    private IEnumerator DelayDisplay()
    {
        yield return new WaitForSeconds(endGameDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
