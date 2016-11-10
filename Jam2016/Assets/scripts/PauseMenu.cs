using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{


    private bool isPaused;
    public GameObject pausa;
  //  public AudioSource audioPlayer;
    

    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            if (isPaused)
            {
            //   audioPlayer.Pause();
                pausa.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
              //  audioPlayer.Play();
                pausa.SetActive(false);
                Time.timeScale = 1f;
            }

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