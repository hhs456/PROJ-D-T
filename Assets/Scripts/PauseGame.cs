using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    private bool isPause;
    public GameObject pauseWindow;

    private void Start()
    {
        isPause = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
    public void Pause()
    {
        isPause = !isPause;

        if (isPause)
        {
            pauseWindow.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pauseWindow.gameObject.SetActive(false);
            Time.timeScale = 1;
        }

    }
    public void Resume()
    {
        isPause = false;
        pauseWindow.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
