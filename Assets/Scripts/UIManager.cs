using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    
    [SerializeField] GameObject GameOverPanel;
    [SerializeField] TMPro.TextMeshProUGUI GameOverTitle;
    [SerializeField] TMPro.TextMeshProUGUI GameOverLabel;

    private void Awake()
    {
        Instance = this;
    }

    public void GameOver(string title, string label)
    {
        if(GameOverPanel.activeSelf) return;

        GameOverPanel.SetActive(true);
        GameOverTitle.SetText(title);
        GameOverLabel.SetText(label);
    }
}
