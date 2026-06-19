using UnityEngine;

public class TrickDetector : MonoBehaviour
{
    public int baseFlipScore = 50;
    public AudioClip trickSFX;

    private float previousRotation;
    private float totalRotation = 0f;
    private int currentMultiplier = 1;

    void Start()
    {
        previousRotation = transform.eulerAngles.z;
    }

    void Update()
    {
        float currentRotation = transform.eulerAngles.z;
        float deltaRotation = Mathf.DeltaAngle(previousRotation, currentRotation);

        totalRotation += Mathf.Abs(deltaRotation);
        previousRotation = currentRotation;

        if (totalRotation >= 360f)
        {
            totalRotation -= 360f;

            int pointsEarned = baseFlipScore * currentMultiplier;

            ScoreManager scoreManager = FindFirstObjectByType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.AddScore(pointsEarned);
            }

            if (trickSFX != null)
            {
                AudioSource.PlayClipAtPoint(trickSFX, Camera.main.transform.position);
            }

            currentMultiplier++;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            totalRotation = 0f;
            currentMultiplier = 1;
        }
    }
}