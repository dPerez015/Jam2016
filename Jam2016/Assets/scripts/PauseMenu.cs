using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{


    private bool isPaused;
    public GameObject pausa;

    void Start() {

    }

    void Update()
    {

        if (isPaused)
        {

            pausa.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pausa.SetActive(false);
            Time.timeScale = 1f;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;

        }

    }

    public void Resume()
    {

        isPaused = false;

    }

    public void Salir()
    {

        Application.Quit();
    }
}