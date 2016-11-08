using UnityEngine;
using System.Collections;

public class SpawnButtons : MonoBehaviour {

    private bool isLevelStarted;
    public GameObject currentSong;
    private int currentButton;
    private float currentTime;
    private Song songScript;
    private AudioSource audioControl;
    public GameObject[] typesOfButtons=new GameObject[2];
    public GameObject Arrastre;
    private movimiento scriptMovement;
    private float velMovement;

    void spawn() {
        if (currentButton < songScript.allButtons.Length) {
            if (songScript.allButtons[currentButton].time <= audioControl.time + 5) {
                switch (songScript.allButtons[currentButton].letter) {
                    case 'Q':
                        Instantiate(typesOfButtons[0], new Vector3(((songScript.allButtons[currentButton].player-1)*1.5f)-0.75f, songScript.allButtons[currentButton].time * velMovement, -1.5f), Quaternion.identity, Arrastre.GetComponent<Transform>());
                        currentButton++;
                        //print("Q");
                        break;
                    case '<':
                        Instantiate(typesOfButtons[1], new Vector3(((songScript.allButtons[currentButton].player - 1) * 1.5f) - 0.75f, songScript.allButtons[currentButton].time * velMovement, -1.5f), Quaternion.identity, Arrastre.GetComponent<Transform>());
                        currentButton++;
                        //print("W");
                        break;
                    case '>':
                        Instantiate(typesOfButtons[1], new Vector3(((songScript.allButtons[currentButton].player - 1) * 1.5f) - 0.75f, songScript.allButtons[currentButton].time * velMovement, -1.5f), Quaternion.identity, Arrastre.GetComponent<Transform>());
                        currentButton++;
                        break;
                    case '^':
                        Instantiate(typesOfButtons[1], new Vector3(((songScript.allButtons[currentButton].player - 1) * 1.5f) - 0.75f, songScript.allButtons[currentButton].time * velMovement, -1.5f), Quaternion.identity, Arrastre.GetComponent<Transform>());
                        currentButton++;

                        break;
                }

            }
        }
    }

    void Start() {
        currentButton = 0;
        songScript = currentSong.GetComponent<Song>();
        audioControl = currentSong.GetComponent<AudioSource>();

        scriptMovement = Arrastre.GetComponent<movimiento>();
        
        velMovement=scriptMovement.getVel();
    }

    void Update () {
        velMovement= scriptMovement.getVel();
        spawn();
	}
}
