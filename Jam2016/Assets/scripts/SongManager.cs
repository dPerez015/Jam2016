using UnityEngine;
using System.Collections;

public class SongManager : MonoBehaviour {
    
    public GameObject[] song;
    private AudioSource songControl;
    private AudioSource transitionSound;
    GameObject nowPlaying;
    private int currentSong;
    bool isLoading;

    void Start(){
        currentSong = 0;
        loadNewSong();
        transitionSound = GetComponent<AudioSource>();
    }
    void Update() {
        if (songControl.isPlaying) {
            if (!transitionSound.isPlaying)
            {
                GetComponent<SpawnButtons>().isLevelStarted = true;
            }
            else {
                GetComponent<SpawnButtons>().isLevelStarted = false;
            }
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
        else {
          //  print("final");
            //end u win
        }
    }

    void Transition() {
       GetComponent<AudioSource>().Play();
       songControl.PlayDelayed(GetComponent<AudioSource>().clip.length);
        
    }
  

}
