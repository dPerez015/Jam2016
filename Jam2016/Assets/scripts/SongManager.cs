using UnityEngine;
using System.Collections;

public class SongManager : MonoBehaviour {
    
    public GameObject[] song;
    private AudioSource songControl;
    private AudioSource transitionSound;
    public GameObject nowPlaying;
    private int currentSong;
    bool isLoading;

    void Start(){
        currentSong = -1;
        transitionSound = GetComponent<AudioSource>();
        loadNewSong();
    }
    void Update() {
        if (songControl.isPlaying) {       
          GetComponent<SpawnButtons>().isLevelStarted = true;  
        }

        else {
            loadNewSong();
        }

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
        
    }

    void Transition() {
       GetComponent<AudioSource>().Play();
       songControl.PlayDelayed(GetComponent<AudioSource>().clip.length);
     //  GetComponent<SpawnButtons>().isLevelStarted = true;

    }
  

}
