using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum StatType
{
    Health,
    Damage,
    Speed
}

[System.Serializable]
public class LevelUpChoice
{
    public Sprite icon; // Hình ảnh của lựa chọn
    public string description; // Mô tả lựa chọn
    public StatType statType;   // Loại chỉ số cần tăng
    public float amount;        // Số lượng tăng
}
