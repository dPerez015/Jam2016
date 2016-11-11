using UnityEngine;
using System.Collections;

public class SpawnButtons : MonoBehaviour {

    public bool isLevelStarted;
    public GameObject currentSong;
    
    private float currentTime;
    private Song songScript;
    private AudioSource audioControl;

    private int currentButton;
    public GameObject Boton;
    private GameObject createdBoton;
    private ButtonScript scriptButton;
    public Sprite[] typesOfButtons=new Sprite[8];

    public GameObject Arrastre;
    private movimiento scriptMovement;
    private float velMovement;

    private int spawnRange;
    void spawn() {
        if (currentButton < songScript.allButtons.Length) {
           // print(currentButton);
            if (songScript.allButtons[currentButton].time <= audioControl.time + spawnRange) {
               //print("tiempo de Spawn: " + songScript.allButtons[currentButton].time + "   " + spawnRange);
                if (!(songScript.allButtons[currentButton].time - spawnRange <= 0))
                {
                    switch (songScript.allButtons[currentButton].letter)
                    {
                        case 'Q':
                            createdBoton = (GameObject)Instantiate(Boton, new Vector3(((songScript.allButtons[currentButton].player - 1) * 2.9f) - 1.45f, spawnRange * velMovement, -1.5f), Quaternion.identity, Arrastre.GetComponent<Transform>());
                            scriptButton = createdBoton.GetComponent<ButtonScript>();
                            scriptButton.initButton(typesOfButtons[0], 'Q');
                            currentButton++;

                            break;
                        case 'W':
                            createdBoton = (GameObject)Instantiate(Boton, new Vector3(((songScript.allButtons[currentButton].player - 1) * 2.9f) - 1.45f, spawnRange * velMovement, -1.5f), Quaternion.identity, Arrastre.GetComponent<Transform>());
                            scriptButton = createdBoton.GetComponent<ButtonScript>();
                            scriptButton.initButton(typesOfButtons[1], 'W');
                            currentButton++;

                            break;
                        case 'E':
                            createdBoton = (GameObject)Instantiate(Boton, new Vector3(((songScript.allButtons[currentButton].player - 1) * 2.9f) - 1.45f, spawnRange * velMovement, -1.5f), Quaternion.identity, Arrastre.GetComponent<Transform>());
                            scriptButton = createdBoton.GetComponent<ButtonScript>();
                            scriptButton.initButton(typesOfButtons[2], 'E');
                            currentButton++;

                            break;
                        case 'R':
                            createdBoton = (GameObject)Instantiate(Boton, new Vector3(((songScript.allButtons[currentButton].player - 1) * 2.9f) - 1.45f, spawnRange * velMovement, -1.5f), Quaternion.identity, Arrastre.GetComponent<Transform>());
                            scriptButton = createdBoton.GetComponent<ButtonScript>();
                            scriptButton.initButton(typesOfButtons[3], 'R');
                            currentButton++;

                            break;
                        case '^':
                            createdBoton = (GameObject)Instantiate(Boton, new Vector3(((songScript.allButtons[currentButton].player - 1) * 2.9f) - 1.45f, spawnRange * velMovement, -1.5f), Quaternion.identity, Arrastre.GetComponent<Transform>());
                            scriptButton = createdBoton.GetComponent<ButtonScript>();
                            scriptButton.initButton(typesOfButtons[4], 'U');
                            currentButton++;

                            break;
                        case '<':
                            createdBoton = (GameObject)Instantiate(Boton, new Vector3(((songScript.allButtons[currentButton].player - 1) * 2.9f) - 1.45f, spawnRange * velMovement, -1.5f), Quaternion.identity, Arrastre.GetComponent<Transform>());
                            scriptButton = createdBoton.GetComponent<ButtonScript>();
                            scriptButton.initButton(typesOfButtons[5], 'L');
                            currentButton++;
                            break;

                        case 'D':
                            createdBoton = (GameObject)Instantiate(Boton, new Vector3(((songScript.allButtons[currentButton].player - 1) * 2.9f) - 1.45f, spawnRange * velMovement, -1.5f), Quaternion.identity, Arrastre.GetComponent<Transform>());
                            scriptButton = createdBoton.GetComponent<ButtonScript>();
                            scriptButton.initButton(typesOfButtons[6], 'D');
                            currentButton++;
                            break;
                        case '>':
                            createdBoton = (GameObject)Instantiate(Boton, new Vector3(((songScript.allButtons[currentButton].player - 1) * 2.9f) - 1.45f, spawnRange * velMovement, -1.5f), Quaternion.identity, Arrastre.GetComponent<Transform>());
                            scriptButton = createdBoton.GetComponent<ButtonScript>();
                            scriptButton.initButton(typesOfButtons[7], 'X');
                            currentButton++;

                            break;
                    }
                }
                else {
                    switch (songScript.allButtons[currentButton].letter)
                    {
                        case 'Q':
                            print("entra Q");
                            createdBoton = (GameObject)Instantiate(Boton, new Vector3(((songScript.allButtons[currentButton].player - 1) * 2.9f) - 1.45f, songScript.allButtons[currentButton].time * velMovement, -1.5f), Quaternion.identity, Arrastre.GetComponent<Transform>());
                            scriptButton = createdBoton.GetComponent<ButtonScript>();
                            scriptButton.initButton(typesOfButtons[0], 'Q');
                            currentButton++;

                            break;
                        case 'W':
                            createdBoton = (GameObject)Instantiate(Boton, new Vector3(((songScript.allButtons[currentButton].player - 1) * 2.9f) - 1.45f, songScript.allButtons[currentButton].time * velMovement, -1.5f), Quaternion.identity, Arrastre.GetComponent<Transform>());
                            scriptButton = createdBoton.GetComponent<ButtonScript>();
                            scriptButton.initButton(typesOfButtons[1], 'W');
                            currentButton++;

                            break;
                        case 'E':
                            createdBoton = (GameObject)Instantiate(Boton, new Vector3(((songScript.allButtons[currentButton].player - 1) * 2.9f) - 1.45f, songScript.allButtons[currentButton].time * velMovement, -1.5f), Quaternion.identity, Arrastre.GetComponent<Transform>());
                            scriptButton = createdBoton.GetComponent<ButtonScript>();
                            scriptButton.initButton(typesOfButtons[2], 'E');
                            currentButton++;

                            break;
                        case 'R':
                            createdBoton = (GameObject)Instantiate(Boton, new Vector3(((songScript.allButtons[currentButton].player - 1) * 2.9f) - 1.45f, songScript.allButtons[currentButton].time * velMovement, -1.5f), Quaternion.identity, Arrastre.GetComponent<Transform>());
                            scriptButton = createdBoton.GetComponent<ButtonScript>();
                            scriptButton.initButton(typesOfButtons[3], 'R');
                            currentButton++;

                            break;
                        case '^':
                            createdBoton = (GameObject)Instantiate(Boton, new Vector3(((songScript.allButtons[currentButton].player - 1) * 2.9f) - 1.45f, songScript.allButtons[currentButton].time * velMovement, -1.5f), Quaternion.identity, Arrastre.GetComponent<Transform>());
                            scriptButton = createdBoton.GetComponent<ButtonScript>();
                            scriptButton.initButton(typesOfButtons[4], 'U');
                            currentButton++;

                            break;
                        case '<':
                            createdBoton = (GameObject)Instantiate(Boton, new Vector3(((songScript.allButtons[currentButton].player - 1) * 2.9f) - 1.45f, songScript.allButtons[currentButton].time * velMovement, -1.5f), Quaternion.identity, Arrastre.GetComponent<Transform>());
                            scriptButton = createdBoton.GetComponent<ButtonScript>();
                            scriptButton.initButton(typesOfButtons[5], 'L');
                            currentButton++;
                            break;

                        case 'D':
                            createdBoton = (GameObject)Instantiate(Boton, new Vector3(((songScript.allButtons[currentButton].player - 1) * 2.9f) - 1.45f, songScript.allButtons[currentButton].time * velMovement, -1.5f), Quaternion.identity, Arrastre.GetComponent<Transform>());
                            scriptButton = createdBoton.GetComponent<ButtonScript>();
                            scriptButton.initButton(typesOfButtons[6], 'D');
                            currentButton++;
                            break;
                        case '>':
                            createdBoton = (GameObject)Instantiate(Boton, new Vector3(((songScript.allButtons[currentButton].player - 1) * 2.9f) - 1.45f, songScript.allButtons[currentButton].time * velMovement, -1.5f), Quaternion.identity, Arrastre.GetComponent<Transform>());
                            scriptButton = createdBoton.GetComponent<ButtonScript>();
                            scriptButton.initButton(typesOfButtons[7], 'X');
                            currentButton++;

                            break;
                    }


                }

            }
        }
    }

    public void setNewScript() {
        songScript = currentSong.GetComponent<Song>();
        audioControl = currentSong.GetComponent<AudioSource>();
    }

    void Start() {
        currentButton = 0;
        spawnRange = 5;
        isLevelStarted = false;
        songScript = currentSong.GetComponent<Song>();

        audioControl = currentSong.GetComponent<AudioSource>();

        scriptMovement = Arrastre.GetComponent<movimiento>();
        
        velMovement=scriptMovement.getVel();
    }

    void Update(){
        velMovement = scriptMovement.getVel();
        if (isLevelStarted) {
            currentTime = audioControl.time;
            spawn(); }
    }

    void OnTriggerEnter2D(Collider2D col) {
        Destroy(col.gameObject);
    }
}
