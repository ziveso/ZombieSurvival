using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public Transform canvas;
    public GameObject player;

    public void Pause()
    {
        canvas.gameObject.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0;
        player.GetComponent<Player>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume()
    {
        canvas.gameObject.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1;
        player.GetComponent<Player>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
        Resume();

        player.GetComponent<Player>().ResetScore();
    }

    public void Leave()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvas.gameObject.activeInHierarchy == false)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }
}
