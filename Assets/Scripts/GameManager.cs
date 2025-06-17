using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    //�ð��̾�� ���⸸��
    [Header("UI Components")]
    public TextMeshProUGUI m_scoreText;
    public TextMeshProUGUI m_timerText;
    public GameObject m_gameClearUI;
    public TextMeshProUGUI m_finalScoreText;
    public Button m_restartButton;

    public bool IsGamePlay { get; set; } = false;

    private int score = 0;
    private float gameTime = 5.0f;
    private float currentTime;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //�ܺ� �����Լ�
    public void GameStart()
    {
        InitializeGame();
    }

    void Update()
    {
        if (IsGamePlay)
        {
            UpdateTimer();
        }   
    }

    void InitializeGame()
    {
        currentTime = gameTime;
        IsGamePlay = true;
        score = 0;

        UpdateScoreText();
        UpdateTimerText();

        if (m_gameClearUI != null)
        {
            m_gameClearUI.SetActive(false);
        }

        if (m_restartButton != null)
        {
            m_restartButton.onClick.RemoveAllListeners();
            m_restartButton.onClick.AddListener(RestartGame);
        }
    }

    void UpdateTimer()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;
            GameClear();
        }
        else
        {
            UpdateTimerText();
        }
    }

    void UpdateTimerText()
    {
        if (m_timerText != null)
        {
            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);

            // ���ڿ� ���� ��� - �� �б� ���� ������
            m_timerText.text = $"Time: {minutes:00}:{seconds:00}";
        }
    }

    public void AddScore(int amount)
    {
        if (IsGamePlay)
        {
            score += amount;
            UpdateScoreText();
        }
    }

    void UpdateScoreText()
    {
        if (m_scoreText != null)
        {
            // ���ڿ� ���� ��� - õ ���� �޸� �߰�
            m_scoreText.text = $"Score: {score:N0}";
        }
    }

    void GameClear()
    {
        IsGamePlay = false;

        if (m_gameClearUI != null)
        {
            m_gameClearUI.SetActive(true);
        }

        if (m_finalScoreText != null)
        {
            m_finalScoreText.text = $"GameClear!\nYour Score : {score}";
        }
    }

    public void RestartGame()
    {
        InitializeGame();

        GameObject[] rats = GameObject.FindGameObjectsWithTag("Rat");
       Debug.Log($"���ŵ� �� ����: {rats.Length}");

        foreach (GameObject rat in rats)
        {
            Destroy(rat);
        }
    }

    public void EndGame()
    {
        GameClear();
    }
}
