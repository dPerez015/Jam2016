﻿using UnityEngine;
using System.Collections;

public class SongManager : MonoBehaviour {

    public SongTextManager songText;
    public GameObject[] song;
    private AudioSource songControl;
    private AudioSource transitionSound;
    public GameObject nowPlaying;
    private int currentSong;
    bool isLoading;

    void Start(){
        songText = FindObjectOfType<SongTextManager>();
        currentSong = -1;
        transitionSound = GetComponent<AudioSource>();
        loadNewSong();
        songText.gameObject.SetActive(false);
    }
    void Update() {
        if (songControl.isPlaying) {       
          GetComponent<SpawnButtons>().isLevelStarted = true;  
        }

        else {
            loadNewSong();
        }

    }

    void StopShowin() {
        songText.gameObject.SetActive(false);
    }

    public void loadNewSong() {


        GetComponent<SpawnButtons>().isLevelStarted = false;
        currentSong += 1;
        if (currentSong < song.Length){
            if (nowPlaying!=null) { Destroy(nowPlaying); };
            nowPlaying = (GameObject)Instantiate(song[currentSong]);
            songControl = nowPlaying.GetComponent<AudioSource>();

            GetComponent<SpawnButtons>().currentSong=nowPlaying;
            GetComponent<SpawnButtons>().setNewScript();
            // print("is loading" +songControl.isPlaying);
            Transition();
        }
        else
        {
            currentSong = 0;
            if (nowPlaying != null) { Destroy(nowPlaying); };
            nowPlaying = (GameObject)Instantiate(song[currentSong]);
            songControl = nowPlaying.GetComponent<AudioSource>();

            GetComponent<SpawnButtons>().currentSong = nowPlaying;
            GetComponent<SpawnButtons>().setNewScript();
            // print("is loading" +songControl.isPlaying);
            Transition();

        }

        //songText.name = AQUI IGUALAR EL NOMBRE A UNA STRING PUBLICA DE CADA CANCION
        
        songText.gameObject.SetActive(true);

        Invoke("StopShowin", 2f);
    }

    void Transition() {
       GetComponent<AudioSource>().Play();
       songControl.PlayDelayed(GetComponent<AudioSource>().clip.length);
     //  GetComponent<SpawnButtons>().isLevelStarted = true;

    }
  

}
