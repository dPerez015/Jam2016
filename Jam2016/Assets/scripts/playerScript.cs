using UnityEngine;
using System.Collections;

public class playerScript : MonoBehaviour {
    public bool canDie;
    const int UP = 0;
    const int DOWN = 1;
    const int LEFT = 3;
    const int RIGHT = 2;
    const int Q = 4;
    const int W = 5;
    const int E = 6;
    const int R = 7;

    public int notasSeguidas;
    public bool isAlive = true;

    public float reguladorSpeed=1;

    InputHandlerScript inputHandler;

    public int lives;

    ScoreManager scoreManager;
    public GameObject managerObject;

    public GameObject nextButton;
    ButtonScript nextButtonScript;
    ButtonScript secondButtonScript;
    public GameObject secondButton;

    public bool hasMissed;
    public bool isOkL;
    public bool isPerfL;
    public bool isOkR;
    public bool isPerfR;
    public char teclaF;
    public char teclaS;

    // Use this for initialization
    void Start() {

        lives = 5;
        inputHandler = GetComponent<InputHandlerScript>();
        scoreManager = managerObject.GetComponent<ScoreManager>();
        nextButton = null;
        secondButton = null;
    }

    // Update is called once per frame
    void Update() {
        
        if (lives < 1&&canDie) {
            isAlive = false;
        }
       Time.timeScale = reguladorSpeed;
        Check();
        CheckPress();
        CheckMistake();
        CheckNotasSeguidas();
     //   print(nextButton!=null);
     
    }

    //este no hace falta llamarlo una vez por segundo
    //solo hace falta llamarlo cuando entra o sale un boton

    void CheckNotasSeguidas() {
        if (notasSeguidas > 10) {
            gainALife();
            notasSeguidas = 0;
        }
    }

    void gainALife() {
        lives++;
    }

    void Check()
    {
        if (nextButton != null) {

            teclaF = nextButtonScript.tecla;
        }
        if (secondButton != null) {
            teclaS = secondButtonScript.tecla;
        }

    }

    void CheckMistake() {
        if ((inputHandler.aKeyPressedNext && nextButton == null )|| (inputHandler.aKeyPressedSecond && secondButton == null)) {
            lives--;
            notasSeguidas = 0;
            Debug.Log("DON'T PRESS");
        }
    }

    void CheckPress() {
        CheckPressLeft();
        CheckPressRight();
    }

    void CheckPressLeft(){
        //es necesario el isOk||isperf? si hay algo en el collider (y portanto el boton existe) isOk siempre sera true 
        if (inputHandler.aKeyPressedSecond && secondButton != null)
        {
            switch (teclaS)
            { //si hacemos un define donde igualemos cada una de las posibilidades sean los numeros concretos funcionarà?
                case 'Q':
                    secondButtonScript.wasPressed = inputHandler.pressings[Q];
                    break;
                case 'W':
                    secondButtonScript.wasPressed = inputHandler.pressings[W];
                    break;
                case 'E':
                    secondButtonScript.wasPressed = inputHandler.pressings[E];
                    break;
                case 'R':
                    secondButtonScript.wasPressed = inputHandler.pressings[R];
                    break;
            }
            if (!secondButtonScript.wasPressed && lives > 0)
            {
                Debug.Log("Left Mistake"); 
                lives--;
                notasSeguidas = 0;
            }
            else if (secondButtonScript.wasPressed) {
                if (isOkL && !isPerfL&&!secondButtonScript.hasScored) {
                    scoreManager.sumOk();
                    notasSeguidas++;
                    secondButtonScript.hasScored = true;
                }
                else if (!isOkL &&  isPerfL&&!secondButtonScript.hasScored) {
                    scoreManager.sumPerf();
                    notasSeguidas++;
                    secondButtonScript.hasScored = true;
                }
            }

        }
    }

    void CheckPressRight(){
        //quita vidas cuando nextButton=null y pulsas una tecla?
        if (inputHandler.aKeyPressedNext && nextButton != null)
        {
            switch (teclaF)
            {
                //cambiar esto a una asignacion si podemos (mucho mas eficiente)
                case 'U':
                    nextButtonScript.wasPressed = inputHandler.pressings[UP];                    

                    break;
                case 'D':
                    nextButtonScript.wasPressed = inputHandler.pressings[DOWN];
                    break;
                case 'X':
                    nextButtonScript.wasPressed = inputHandler.pressings[RIGHT];
                    break;
                case 'L':
                    nextButtonScript.wasPressed = inputHandler.pressings[LEFT];
                    break;
            }
            if (!nextButtonScript.wasPressed && lives > 0)
            {
                lives--;
                Debug.Log("Right mistake");
            }
            else if (nextButtonScript.wasPressed)
            {
                if (isOkR && !isPerfR&&!nextButtonScript.hasScored)
                {
                    scoreManager.sumOk();
                    nextButtonScript.hasScored = true;                    
                }
                else if (!isOkR && isPerfR && !nextButtonScript.hasScored)
                {
                    scoreManager.sumPerf();
                    nextButtonScript.hasScored = true;
                }
            }
        }


    }

    void OnTriggerEnter2D(Collider2D col)
    {

        //print("entra");
        GameObject unBoton;
        ButtonScript unBotonScript;
        char laTecla;

        if (col.tag == "OK")
        {
            unBoton = col.gameObject;
            unBotonScript = unBoton.GetComponent<ButtonScript>();
            laTecla = unBotonScript.tecla;


            if (laTecla == 'U' || laTecla == 'D' || laTecla == 'X' || laTecla == 'L'){
                nextButton = unBoton;
                Debug.Log(laTecla);
                nextButtonScript = unBotonScript;
                isOkR = true;
                
            }
            else if (laTecla == 'Q' || laTecla == 'W' || laTecla == 'E' || laTecla == 'R'){
                isOkL = true;
                secondButton = unBoton;
                secondButtonScript = unBotonScript;
            }
        }
        else if (col.tag == "Perfect")
        {
            unBoton = col.gameObject;
            unBotonScript = unBoton.GetComponentInParent(typeof(ButtonScript)) as ButtonScript;
            laTecla = unBotonScript.tecla;


            if (laTecla == 'U' || laTecla == 'D' || laTecla == 'X' || laTecla == 'L')
            {
                isOkR = false;
                isPerfR = true;
            }
            else if (laTecla == 'Q' || laTecla == 'W' || laTecla == 'E' || laTecla == 'R')
            {
                isOkL = false;
                isPerfL = true;
            }
           
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {

        GameObject unBoton;
        ButtonScript unBotonScript;
        char laTecla;

        if (col.tag == "OK")
        {
            unBoton = col.gameObject;
            unBotonScript = unBoton.GetComponent<ButtonScript>();

            laTecla = unBotonScript.tecla;
            if (laTecla == 'U' || laTecla == 'D' || laTecla == 'X' || laTecla == 'L')
            {
                //  nextButton = unBoton;
                Debug.Log("exited");
                isOkR = false;
                nextButton = null;
                secondButton = null;
            }
            else if (laTecla == 'Q' || laTecla == 'W' || laTecla == 'E' || laTecla == 'R')
            {
             //   nextButton = unBoton;
                isOkL = false;
                nextButton = null;
                secondButton = null;
            }
            if (!unBotonScript.wasPressed) {
                unBotonScript.haPasado = true;
            }
        }
        else if (col.tag == "Perfect")
        {

            unBoton = col.gameObject;
            unBotonScript = unBoton.GetComponentInParent(typeof(ButtonScript)) as ButtonScript;
            laTecla = unBotonScript.tecla;


            if (laTecla == 'U' || laTecla == 'D' || laTecla == 'X' || laTecla == 'L')
            {

                isPerfR = false;
                isOkR = true;
            }
            else if (laTecla == 'Q' || laTecla == 'W' || laTecla == 'E' || laTecla == 'R')
            {

                isPerfL = false;
                isOkL = true;
            }

        }
    }

  
}

