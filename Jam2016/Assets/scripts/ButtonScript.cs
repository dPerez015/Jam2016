using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {
    public char tecla;
   public bool wasPressed;
   public bool haPasado;
   public bool hasScored;
   public bool canBePressed;
   public bool hasTakenLife;
    

    playerScript eljugador;
    public GameObject jugadorObject;
	// Use this for initialization
	void Start () {
        jugadorObject = GameObject.FindWithTag("Player");

        eljugador = jugadorObject.GetComponent<playerScript>();
        wasPressed = false;
        haPasado = false;
        hasScored = false; 
	}

    public void initButton(Sprite s, char t){
        GetComponent<SpriteRenderer>().sprite = s;
        tecla = t;
        }
	
	// Update is called once per frame
	void Update () {
        
        if (haPasado && !wasPressed&&!hasTakenLife) {
            eljugador.lives--;
            eljugador.notasSeguidas = 0;
            hasTakenLife = true;
        }
	}

    
}
