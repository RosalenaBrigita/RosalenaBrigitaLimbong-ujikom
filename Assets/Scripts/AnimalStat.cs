using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalStat : MonoBehaviour
{
    public float maxHungerNeed = 200f;
    private float hungerNeed = 0f;
    public int score;
    private ScoreManager scoreManager;

    void Start()
    {
        hungerNeed = 0f;

        scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager == null)
        {
            Debug.LogWarning("ScoreManager tidak ditemukan!");
        }
    }

    void Update()
    {
        if (hungerNeed >= maxHungerNeed)
        {
            if (scoreManager != null)
            {
                scoreManager.AddScore(score);
            }

            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            hungerNeed += 25f;

            hungerNeed = Mathf.Min(hungerNeed, maxHungerNeed);

            Destroy(other.gameObject);
        }
    }
}
