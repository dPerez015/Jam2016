using UnityEngine;
using System.Collections;

public class SpawnButtons : MonoBehaviour {

    private bool isLevelStarted;
    public GameObject currentSong;
    private int currentButton;
    private float currentTime;
    private Song songScript;
    private AudioSource audioControl;
    public GameObject Boton;
    private GameObject createdBoton;
    private ButtonScript scriptButton;
    public Sprite[] typesOfButtons=new Sprite[8];
    public GameObject Arrastre;
    private movimiento scriptMovement;
    private float velMovement;

    void spawn() {
        if (currentButton < songScript.allButtons.Length) {
            if (songScript.allButtons[currentButton].time <= audioControl.time + 5) {
                switch (songScript.allButtons[currentButton].letter) {
                    case 'Q':
                        createdBoton=(GameObject)Instantiate(Boton, new Vector3(((songScript.allButtons[currentButton].player-1)*2.8f)- 1.4f, songScript.allButtons[currentButton].time * velMovement, -1.5f), Quaternion.identity, Arrastre.GetComponent<Transform>());
                        scriptButton = createdBoton.GetComponent<ButtonScript>();
                        scriptButton.initButton(typesOfButtons[0],'Q');
                        currentButton++;
                        
                        break;
                    case 'W':
                        createdBoton = (GameObject)Instantiate(Boton, new Vector3(((songScript.allButtons[currentButton].player - 1) * 2.5f) - 1.25f, songScript.allButtons[currentButton].time * velMovement, -1.5f), Quaternion.identity, Arrastre.GetComponent<Transform>());
                        scriptButton = createdBoton.GetComponent<ButtonScript>();
                        scriptButton.initButton(typesOfButtons[1], 'W');
                        currentButton++;

                        break;
                    case 'E':
                        createdBoton = (GameObject)Instantiate(Boton, new Vector3(((songScript.allButtons[currentButton].player - 1) * 2.5f) - 1.25f, songScript.allButtons[currentButton].time * velMovement, -1.5f), Quaternion.identity, Arrastre.GetComponent<Transform>());
                        scriptButton = createdBoton.GetComponent<ButtonScript>();
                        scriptButton.initButton(typesOfButtons[2], 'E');
                        currentButton++;

                        break;
                    case 'R':
                        createdBoton = (GameObject)Instantiate(Boton, new Vector3(((songScript.allButtons[currentButton].player - 1) * 2.5f) - 1.25f, songScript.allButtons[currentButton].time * velMovement, -1.5f), Quaternion.identity, Arrastre.GetComponent<Transform>());
                        scriptButton = createdBoton.GetComponent<ButtonScript>();
                        scriptButton.initButton(typesOfButtons[3], 'R');
                        currentButton++;

                        break;
                    case '^':
                        createdBoton = (GameObject)Instantiate(Boton, new Vector3(((songScript.allButtons[currentButton].player - 1) * 2.5f) - 1.25f, songScript.allButtons[currentButton].time * velMovement, -1.5f), Quaternion.identity, Arrastre.GetComponent<Transform>());
                        scriptButton = createdBoton.GetComponent<ButtonScript>();
                        scriptButton.initButton(typesOfButtons[4], 'U');
                        currentButton++;

                        break;
                    case '<':
                        createdBoton = (GameObject)Instantiate(Boton, new Vector3(((songScript.allButtons[currentButton].player - 1) * 2.5f) - 1.25f, songScript.allButtons[currentButton].time * velMovement, -1.5f), Quaternion.identity, Arrastre.GetComponent<Transform>());
                        scriptButton = createdBoton.GetComponent<ButtonScript>();
                        scriptButton.initButton(typesOfButtons[5], 'L');
                        currentButton++;
                        break;

                    case 'D':
                        createdBoton = (GameObject)Instantiate(Boton, new Vector3(((songScript.allButtons[currentButton].player - 1) * 2.5f) - 1.25f, songScript.allButtons[currentButton].time * velMovement, -1.5f), Quaternion.identity, Arrastre.GetComponent<Transform>());
                        scriptButton = createdBoton.GetComponent<ButtonScript>();
                        scriptButton.initButton(typesOfButtons[6], 'D');
                        currentButton++;
                        break;
                    case '>':
                        createdBoton = (GameObject)Instantiate(Boton, new Vector3(((songScript.allButtons[currentButton].player - 1) * 2.5f) - 1.25f, songScript.allButtons[currentButton].time * velMovement, -1.5f), Quaternion.identity, Arrastre.GetComponent<Transform>());
                        scriptButton = createdBoton.GetComponent<ButtonScript>();
                        scriptButton.initButton(typesOfButtons[7], 'X');
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
