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
    

    ScoreManager theManager;
    InputHandlerScript inputHandler;

    public int lives;

    public GameObject managerObject;

    public GameObject nextButton;
    ButtonScript nextButtonScript;
    ButtonScript secondButtonScript;
    public GameObject secondButton;


    public bool hasMissed;
    public bool isOk;
    public bool isPerf;

    char teclaF;
    char teclaS;

    // Use this for initialization
    void Start() {
        lives = 3;
        inputHandler = GetComponent<InputHandlerScript>();
        theManager = managerObject.GetComponent<ScoreManager>();
        nextButton = null;
        secondButton = null;
    }

    // Update is called once per frame
    void Update() {

        CheckPress();
        Check();


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


    void CheckPress() {
        CheckPressLeft();
        CheckPressRight();
    }

    void CheckPressLeft()
    {
        if (inputHandler.aKeyPressed && nextButton != null && (isOk||isPerf))
        {
            switch (teclaF)
            {
                case 'U':
                    nextButtonScript.wasPressed = (teclaF == inputHandler.charArray[UP]);

                    break;
                case 'D':
                    nextButtonScript.wasPressed = (teclaF == inputHandler.charArray[DOWN]);
                    break;
                case 'X':
                    nextButtonScript.wasPressed = (teclaF == inputHandler.charArray[RIGHT]);
                    break;
                case 'L':
                    nextButtonScript.wasPressed = (teclaF == inputHandler.charArray[LEFT]);
                    break;
            }
            if (!nextButtonScript.wasPressed) {
                lives--;
            } 
        }
    }

    void CheckPressRight()
    {
        if (inputHandler.aKeyPressed && secondButton != null && (isOk || isPerf))
        {
            switch (secondButtonScript.tecla)
            {
                case 'Q':
                    secondButtonScript.wasPressed = (teclaS == inputHandler.charArray[Q]);
                    break;
                case 'W':
                    secondButtonScript.wasPressed = (teclaS == inputHandler.charArray[W]);
                    break;
                case 'E':
                    secondButtonScript.wasPressed = (teclaS == inputHandler.charArray[E]);
                    break;
                case 'R':
                    secondButtonScript.wasPressed = (teclaS == inputHandler.charArray[R]);
                    break;
            }
            if (!secondButtonScript.wasPressed)
            {
                lives--;
            }

        }
    }

    void OntriggerEnter2D(Collider2D col)
    {
        GameObject unBoton;
        ButtonScript unBotonScript;
        char laTecla;
        if (col.tag == "OK")
        {
            isOk = true;
            unBoton = col.gameObject;
            unBotonScript = unBoton.GetComponent<ButtonScript>();
            laTecla = unBotonScript.tecla;
            if (laTecla == 'U' || laTecla == 'D' || laTecla == 'X' || laTecla == 'L')
            {
                nextButton = unBoton;
                nextButtonScript = unBotonScript;
            } else if (laTecla == 'Q' || laTecla == 'W' || laTecla == 'E' || laTecla == 'R')
            {
                secondButton = unBoton;
                secondButtonScript = unBotonScript;
            }
        }
        else if (col.tag == "Perfect")
        {
            isOk = false;
            isPerf = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "OK")
        {
            isOk = false;
            nextButton = null;
            secondButton = null;
        }
        else if (col.tag == "Perfect")
        {
            isPerf = false;
            isOk = true;
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

