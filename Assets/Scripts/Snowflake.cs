using UnityEngine;

public class Snowflake : MonoBehaviour
{
    public int pointValue = 10;
    public AudioClip collectSFX;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager scoreManager = FindFirstObjectByType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.AddScore(pointValue);
            }

            if (collectSFX != null)
            {
                AudioSource.PlayClipAtPoint(collectSFX, Camera.main.transform.position);
            }

            Destroy(gameObject);
        }
    }
}