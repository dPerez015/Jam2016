using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{

    GameObject eljugador;
    playerScript eljugadorScript;
    private bool isPaused;
    public GameObject pausa;
    public GameObject death;
    public GameObject aLevelManager;
    SongManager aSongManager;
    //  public AudioSource audioPlayer

    void Start() {
        eljugador = GameObject.FindWithTag("Player");
        death.SetActive(false);
        eljugadorScript = eljugador.GetComponent<playerScript>();
        aSongManager = aLevelManager.GetComponent<SongManager>();
    }

    void Update(){
        if (eljugadorScript.isAlive)
        { 
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = !isPaused;
                if (isPaused)
                {
                    aSongManager.nowPlaying.GetComponent<AudioSource>().Pause();
                    //   audioPlayer.Pause();

                    pausa.SetActive(true);
                    Time.timeScale = 0f;
                }
                else
                {
                    //  audioPlayer.Play();
                    aSongManager.nowPlaying.GetComponent<AudioSource>().Play();
                    pausa.SetActive(false);
                    Time.timeScale = 1f;
                }
            }

        }
        else {
            death.SetActive(true);
            Time.timeScale = 0f;
            aSongManager.nowPlaying.GetComponent<AudioSource>().Stop();
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