using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // 싱글톤 인스턴스
    [Tooltip("TextMeshPro ADD Please")]
    public TextMeshProUGUI m_scoreText; // 점수를 표시할 UI 텍스트

    public bool IsGamePlay { get; set; } = true;

    private int score = 0;


    void Awake()
    {
        // 싱글톤 패턴 설정
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (m_scoreText != null)
        {
            m_scoreText.text = "Score: " + score;
        }
    }
}
