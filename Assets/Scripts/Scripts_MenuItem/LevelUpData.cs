using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelUpData", menuName = "Game/LevelUpData")]
public class LevelUpData : ScriptableObject
{
    public List<LevelData> levelUpChoices; // Danh sách dữ liệu cho các cấp độ

    public List<LevelUpChoice> GetChoicesForLevel(int level)
    {
        foreach (var data in levelUpChoices)
        {
            if (data.level == level)
                return data.choices;
        }
        return null; // Không có dữ liệu cho cấp độ này
    }
}
