using UnityEngine;
using System.Collections;

public class movimientoOscuro : MonoBehaviour {
    Vector3 posUpgrades;
    public GameObject thePlayer;
    playerScript player;
    int numLifes;
    int currentLifes;

    void Start() {
        posUpgrades = new Vector3(0,0.5f,0);
        player = thePlayer.GetComponent<playerScript>();
        numLifes = player.lives;
    }
	void Update () {
        currentLifes = player.lives;
        transform.position = posUpgrades * (numLifes-currentLifes);
	}
}
