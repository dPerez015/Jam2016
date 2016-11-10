using UnityEngine;
using System.Collections;

public class playerScript : MonoBehaviour {

    const int UP = 0;
    const int DOWN = 1;
    const int LEFT = 2;
    const int RIGHT = 3;
    const int Q = 4;
    const int W = 5;
    const int E = 6;
    const int R = 7;

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
    char teclaF;
    char teclaS;

    // Use this for initialization
    void Start() {
        lives = 3;
        inputHandler = GetComponent<InputHandlerScript>();
        scoreManager = managerObject.GetComponent<ScoreManager>();
        nextButton = null;
        secondButton = null;
    }

    // Update is called once per frame
    void Update() {

        CheckPress();
        Check();
     //   print(nextButton!=null);

    }

    //este no hace falta llamarlo una vez por segundo
    //solo hace falta llamarlo cuando entra o sale un boton
    void Check()
    {
        if (nextButton != null) {
            print("entra");
            teclaF = nextButtonScript.tecla;
        }
        if (secondButton != null) {
            teclaS = secondButtonScript.tecla;
        }

    }


    void CheckPress() {
        CheckPressLeft();
        CheckPressRight();
    }

    void CheckPressLeft(){
        //es necesario el isOk||isperf? si hay algo en el collider (y portanto el boton existe) isOk siempre sera true 
        if (inputHandler.aKeyPressed && secondButton != null && (isOkR || isPerfR))
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
            if (!secondButtonScript.wasPressed && lives >= 0)
            {
                lives--;
            }
            else if (secondButtonScript.wasPressed) {
                if (isOkL && !isPerfL) {
                    scoreManager.sumOk();

                }
                else if (!isOkL &&  isPerfL) {
                    scoreManager.sumPerf();
                }
            }

        }
    }

    void CheckPressRight(){
        //quita vidas cuando nextButton=null y pulsas una tecla?
        if (inputHandler.aKeyPressed && nextButton != null && (isOkL || isPerfL))
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
            if (!nextButtonScript.wasPressed && lives >= 0)
            {
                lives--;
            }
            else if (secondButtonScript.wasPressed)
            {
                if (isOkR && !isPerfR)
                {
                    scoreManager.sumOk();

                }
                else if (!isOkR && isPerfR)
                {
                    scoreManager.sumPerf();
                }
            }
        }





    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Entra");
        //print("entra");
        GameObject unBoton;
        ButtonScript unBotonScript;
        char laTecla;

        if (col.tag == "OK")
        {
            unBoton = col.gameObject;
            unBotonScript = unBoton.GetComponent<ButtonScript>();
            laTecla = unBotonScript.tecla;
            print (col.tag);

            if (laTecla == 'U' || laTecla == 'D' || laTecla == 'X' || laTecla == 'L'){
                nextButton = unBoton;
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
        Debug.Log("Sale");
        GameObject unBoton;
        ButtonScript unBotonScript;
        char laTecla;

        if (col.tag == "OK")
        {
            unBoton = col.gameObject;
            unBotonScript = unBoton.GetComponent<ButtonScript>();
            print(col.tag);
            laTecla = unBotonScript.tecla;
            if (laTecla == 'U' || laTecla == 'D' || laTecla == 'X' || laTecla == 'L')
            {
              //  nextButton = unBoton;
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

                isPerfR = false;
                isOkR = true;
            }

        }
    }

    /*
    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "OK")
        {
            if (nextButton != null)
            {
                secondButton = col.gameObject;
                secondButtonScript = secondButton.GetComponent<ButtonScript>();
            }
            else {
                nextButton = col.gameObject;
                nextButtonScript = nextButton.GetComponent<ButtonScript>();
            }

            isOk = true;
        }
        else if (col.tag == "Perfect") {
            isPerf = true;
            isOk = false;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "OK")
        {
            if (secondButton != null) {
                secondButtonScript.haPasado = true;
            }
            nextButtonScript.haPasado = true;
            isOk = false;
            nextButton = secondButton = null;
            nextButtonScript = secondButtonScript = null;
        }
        else if (col.tag == "Perfect")
        {
            isPerf = false;
            isOk = true;
        }

    }*/
}

