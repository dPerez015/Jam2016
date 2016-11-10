using UnityEngine;
using System.Collections;

public class SongManager : MonoBehaviour {

    public GameObject song;
    private AudioSource songControl;

    void Start(){
        songControl = song.GetComponent<AudioSource>();
        Time.timeScale = 0f;
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Time.timeScale = 1f;
            songControl.Play();
            
        }
	}
}
