using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    private static GameEvents _instance;
    public static GameEvents Instance => _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this);
            return;
        }

        _instance = this;
    }

    public event Action onGameOver;
    public void GameOver()
    {
        if (onGameOver != null)
        {
            onGameOver();
        }
    }
}
