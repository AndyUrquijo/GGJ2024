using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] GameObject GameOverScreen;
    public void GameOver()
    {
        GameOverScreen.SetActive(true);
    }
}
