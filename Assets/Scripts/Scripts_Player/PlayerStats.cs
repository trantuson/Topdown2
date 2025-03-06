using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public int dame = 10;
    public float speed = 5;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void IncreaseStats(StatType stat, float amount)
    {
        switch (stat)
        {
            case StatType.Health:
                maxHealth += (int)amount;
                currentHealth = Mathf.Min(currentHealth + (int)amount, maxHealth);
                Debug.Log($"Tăng Máu: {amount}, Máu hiện tại: {currentHealth}");
                break;

            case StatType.Damage:
                dame += (int)amount;
                Debug.Log($"Tăng Sát Thương: {amount}, Sát thương hiện tại: {dame}");
                break;

            case StatType.Speed:
                speed += amount;
                Debug.Log($"Tăng Tốc Độ: {amount}, Tốc độ hiện tại: {speed}");
                break;
        }
    }
}
