using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelUpMenuController : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel; // Panel menu
    [SerializeField] private Transform choicesContainer; // Container cho các nút lựa chọn
    [SerializeField] private GameObject choicePrefab; // Prefab cho một lựa chọn
    [SerializeField] private LevelUpData levelUpData; // Dữ liệu level
    private PlayerStats playerStats; // Tham chiếu tới PlayerStats


    private void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>(); // Tìm PlayerStats trong scene
    }
    public void ShowMenu(int level)
    {
        // Xóa các nút cũ
        foreach (Transform child in choicesContainer)
        {
            Destroy(child.gameObject);
        }

        // Lấy danh sách lựa chọn cho cấp độ hiện tại
        List<LevelUpChoice> choices = levelUpData.GetChoicesForLevel(level);

        if (choices != null)
        {
            foreach (var choice in choices)
            {
                GameObject choiceButton = Instantiate(choicePrefab, choicesContainer);
                choiceButton.transform.Find("Icon").GetComponent<Image>().sprite = choice.icon;
                choiceButton.transform.Find("Description").GetComponent<TMP_Text>().text = choice.description;

                Button button = choiceButton.GetComponent<Button>();
                button.onClick.AddListener(() => ApplyChoice(choice));
            }
        }

        menuPanel.SetActive(true);
        Time.timeScale = 0; // Dừng game
    }

    private void ApplyChoice(LevelUpChoice choice)
    {
        // Áp dụng hiệu ứng của lựa chọn
        if (playerStats != null)
        {
            playerStats.IncreaseStats(choice.statType, choice.amount);
        }

        // Ẩn menu
        menuPanel.SetActive(false);
        Time.timeScale = 1; // Tiếp tục game
    }
}
