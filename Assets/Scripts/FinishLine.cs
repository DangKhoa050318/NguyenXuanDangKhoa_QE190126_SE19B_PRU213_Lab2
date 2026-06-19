using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class FinishLine : MonoBehaviour
{
    public ParticleSystem finishEffect;
    public AudioSource finishSFX;
    public GameObject winText;

    public string nextSceneName;

    public bool hasFinished = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (hasFinished == false)
            {
                hasFinished = true;

                if (finishEffect != null)
                {
                    finishEffect.Play();
                }

                if (finishSFX != null)
                {
                    finishSFX.Play();
                }

                if (winText != null)
                {
                    winText.SetActive(true);
                }

                Time.timeScale = 0f;

                StartCoroutine(WaitAndLoadNextScene());
            }
        }
    }

    IEnumerator WaitAndLoadNextScene()
    {
        yield return new WaitForSecondsRealtime(2f);

        Time.timeScale = 1f;

        PlayerPrefs.SetString("NextLevel", nextSceneName);

        SceneManager.LoadScene("WinScene");
    }
}