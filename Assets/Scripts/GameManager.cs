using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // �̱��� �ν��Ͻ�
    [Tooltip("TextMeshPro ADD Please")]
    public TextMeshProUGUI m_scoreText; // ������ ǥ���� UI �ؽ�Ʈ

    public bool IsGamePlay { get; set; } = true;

    private int score = 0;


    void Awake()
    {
        // �̱��� ���� ����
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
