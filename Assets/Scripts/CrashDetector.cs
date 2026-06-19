using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CrashDetector : MonoBehaviour
{
    public AudioSource crashSFX;
    public ParticleSystem crashEffect;
    public GameObject loseText;
    public bool hasCrashed = false;

    Vector3 startPosition;
    Quaternion startRotation;

    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground") && hasCrashed == false)
        {
            hasCrashed = true;

            GetComponent<PlayerController>().DisableControls();

            if (crashSFX != null) crashSFX.Play();
            if (crashEffect != null) crashEffect.Play();
            if (loseText != null) loseText.SetActive(true);

            Time.timeScale = 0f;
            StartCoroutine(WaitAndRespawn());
        }
    }

    IEnumerator WaitAndRespawn()
    {
        yield return new WaitForSecondsRealtime(2f);
        Time.timeScale = 1f;

        int lives = PlayerPrefs.GetInt("PlayerLives", 3);
        lives -= 1;
        PlayerPrefs.SetInt("PlayerLives", lives);

        if (lives > 0)
        {

            if (loseText != null) loseText.SetActive(false);

            transform.position = startPosition;
            transform.rotation = startRotation;

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
                rb.angularVelocity = 0f;
            }

            GetComponent<PlayerController>().canMove = true;
            hasCrashed = false;

            ScoreManager scoreManager = FindFirstObjectByType<ScoreManager>();
            if (scoreManager != null && scoreManager.livesText != null)
            {
                scoreManager.livesText.text = "Lives: " + lives;
            }
        }
        else
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
}