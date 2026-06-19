using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText; 
    public TextMeshProUGUI speedText;

    public Rigidbody2D playerRb;

    void Start()
    {
        score = PlayerPrefs.GetInt("FinalScore", 0);
        int lives = PlayerPrefs.GetInt("PlayerLives", 3);

        UpdateScoreText();
        if (livesText != null)
        {
            livesText.text = "Lives: " + lives;
        }
    }

    void Update()
    {
        if (speedText != null && playerRb != null)
        {
            int speed = Mathf.RoundToInt(playerRb.linearVelocity.magnitude);
            speedText.text = "Speed: " + speed + " km/h";
        }
    }

    public void AddScore(int pointsToAdd)
    {
        score += pointsToAdd;
        UpdateScoreText();
        PlayerPrefs.SetInt("FinalScore", score);
    }

    void UpdateScoreText()
    {
        if (scoreText != null) scoreText.text = "Score: " + score;
    }
}