using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import namespace TextMeshPro

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI scoreText; // Menggunakan TextMeshProUGUI

    void Start()
    {
        score = 0;
        UpdateScoreText(); // Panggil fungsi ini untuk memperbarui teks UI pada awal
    }

    void Update()
    {
        // Update logika lainnya sesuai kebutuhan
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText(); // Panggil fungsi ini setiap kali skor berubah
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString(); // Update teks pada UI Text
        }
    }
}
