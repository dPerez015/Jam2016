using UnityEngine;
using System.Collections;

public class movimiento : MonoBehaviour {
    private float velMovement;
    private Vector3 movementDir;

	void Start () {
        velMovement = 10;
        movementDir = new Vector3(0,-1,0);
	}

    public float getVel() {
        return velMovement;
    }

    void move() {
        transform.position += movementDir * velMovement*Time.deltaTime;
    }
   
	void Update () {
        move();
	}
}
