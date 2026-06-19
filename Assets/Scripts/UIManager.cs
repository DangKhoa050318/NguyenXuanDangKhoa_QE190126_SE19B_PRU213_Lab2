using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject nextStageButton;

    void Start()
    {
        string nextLevel = PlayerPrefs.GetString("NextLevel", "");

        if (nextStageButton != null)
        {
            if (nextLevel != "")
            {
                nextStageButton.SetActive(true);
            }
            else
            {
                nextStageButton.SetActive(false);
            }
        }
    }

    public void NextStage()
    {
        string nextLevel = PlayerPrefs.GetString("NextLevel", "");
        if (nextLevel != "")
        {
            PlayerPrefs.SetInt("FinalScore", 0);
            PlayerPrefs.SetInt("PlayerLives", 3);
            SceneManager.LoadScene(nextLevel);
        }
    }

    public void ReplayGame()
    {
        PlayerPrefs.SetInt("PlayerLives", 3);
        PlayerPrefs.SetInt("FinalScore", 0);
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        Debug.Log("Đã thoát game!");
        Application.Quit();
    }
}