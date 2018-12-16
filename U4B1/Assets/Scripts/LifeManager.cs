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
    private GameObject ship;

    public void Initialize(Image lifeBar, int currentLife, GameObject ship)
    {
        this.lifeBar = lifeBar;
        CurrentLife = currentLife;
        maxLife = currentLife;
        spriteWidth = lifeBar.rectTransform.sizeDelta.x;
        this.ship = ship;
    }

    public void DealDamage(int damage)
    {
        CurrentLife -= damage;

        if (CurrentLife <= 0)
            Destroy(ship);

        lifeBar.rectTransform.sizeDelta = new Vector2(CurrentLife / maxLife * spriteWidth, lifeBar.rectTransform.sizeDelta.y);
    }
}
