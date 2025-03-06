using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeathManager : MonoBehaviour
{
    private PlayerStats playerStats;

    [SerializeField]
    private int health;
    public int currentHealth;

    [SerializeField] private GameObject expPrefabs;

    private void Start()
    {
        if (gameObject.CompareTag("Player"))
        {
            playerStats = GetComponent<PlayerStats>();
            health = playerStats.maxHealth;
        }

        currentHealth = health;

        expPrefabs = GameObject.Find("Exp");
    }
    public void TakeDame(int dame)
    {
        currentHealth -= dame;

        if(gameObject.CompareTag("Player") && playerStats != null)
        {
            playerStats.currentHealth = currentHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            Instantiate(expPrefabs,transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
