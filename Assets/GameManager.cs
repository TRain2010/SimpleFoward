using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameEnded = false;
    public float delay = 5;

    public GameObject completeUI;
    public void EndGame()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            Invoke("Restart", delay);
        }
    }

    public void CompleteLevel()
    {
        completeUI.SetActive(true);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
