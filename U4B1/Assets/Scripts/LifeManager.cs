using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour, ILifeManager
{
    public int CurrentLife { get; private set; }

    private Image lifeBar;
    private float maxLife;
    private float spriteWidth;

    private IGameEnding gameEnding;

    public void Initialize(Image lifeBar, int currentLife, GameObject ship, IGameEnding gameEnding)
    {
        this.lifeBar = lifeBar;
        CurrentLife = currentLife;
        maxLife = currentLife;
        spriteWidth = lifeBar.rectTransform.sizeDelta.x;
        this.gameEnding = gameEnding;
    }

    public void DealDamage(int damage)
    {
        CurrentLife -= damage;

        if (CurrentLife <= 0)
            gameEnding.EndGame();

        lifeBar.rectTransform.sizeDelta = new Vector2(CurrentLife / maxLife * spriteWidth, lifeBar.rectTransform.sizeDelta.y);
    }
}
