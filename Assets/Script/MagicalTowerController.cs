using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MagicalTowerController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Slider healthBar;
    public GameObject gameOverPanel;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.value = (float)currentHealth / maxHealth;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            GameOver();
        }
    }

    private void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
}
