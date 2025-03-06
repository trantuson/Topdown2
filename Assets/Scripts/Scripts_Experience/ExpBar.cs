﻿using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    [SerializeField] private Slider expBar;

    private int baseExp = 10; // exp ban đầu để lên level
    private int expIncrement = 5; // exp cộng thêm khi lên mỗi level

    private int maxExp;
    public int currentExp = 1;

    private int currentLevel;

    [SerializeField] private LevelUpMenuController levelUpMenuController;

    private void Start()
    {
        currentExp = 0;
        maxExp = baseExp;
        UpdateExpBar();
    }
    private void Update()
    {
        UpdateExpBar();
        LevelUp();
    }
    public void ExpPlus(int exp)
    {
        currentExp += exp;
    }
    public void UpdateExpBar()
    {

        expBar.maxValue = maxExp;
        expBar.value = currentExp;

    }
    public void LevelUp()
    {
        if(currentExp >= maxExp)
        {
            Debug.Log("Level Up");
            currentExp -= maxExp;
            baseExp += expIncrement;

            currentLevel++;

            maxExp = baseExp;
            UpdateExpBar();

            // Hiển thị menu cấp độ
            levelUpMenuController.ShowMenu(currentLevel);
        }
    }
}
