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

        Check();
        CheckPress();

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

    void CheckPress()
    {
        //COMPROBACIÓN SI HA PULSADO CORRECTAMENTE EL NEXTBUTTON
        if (inputHandler.aKeyPressed && nextButton != null && isOk || inputHandler.aKeyPressed && nextButton != null && isPerf)
        {
            switch (teclaF)
            {
                case 'Q':
                    if (inputHandler.pressings[Q])
                    {
                        nextButtonScript.wasPressed = true;
                    }
                    break;
                case 'W':
                    if (inputHandler.pressings[W])
                    {
                        nextButtonScript.wasPressed = true;
                    }
                    break;
                case 'E':
                    if (inputHandler.pressings[E])
                    {
                        nextButtonScript.wasPressed = true;
                    }
                    break;
                case 'R':
                    if (inputHandler.pressings[R])
                    {
                        nextButtonScript.wasPressed = true;
                    }
                    break;
                case 'U':
                    if (inputHandler.pressings[UP])
                    {
                        nextButtonScript.wasPressed = true;
                    }
                    break;
                case 'I':
                    if (inputHandler.pressings[DOWN])
                    {
                        nextButtonScript.wasPressed = true;
                    }
                    break;
                case 'O':
                    if (inputHandler.pressings[RIGHT])
                    {
                        nextButtonScript.wasPressed = true;
                    }
                    break;
                case 'P':
                    if (inputHandler.pressings[LEFT])
                    {
                        nextButtonScript.wasPressed = true;
                    }
                    break;

                    if (nextButtonScript.wasPressed && !nextButtonScript.hasScored)
                    {
                        if (isOk)
                        {
                            theManager.score += 100;
                        }
                        else if (isPerf)
                        {
                            theManager.score += 1000;
                        }
                        nextButtonScript.hasScored = true;
                    }
            }
            //COMPROBACION SI HA PULSADO CORRECTAMENTE EL SEGUNDO BOTON

            if (inputHandler.aKeyPressed && secondButton != null && isOk || inputHandler.aKeyPressed && secondButton != null && isPerf)
            {
                switch (teclaS)
                {
                    case 'Q':
                        if (inputHandler.pressings[Q])
                        {
                            secondButtonScript.wasPressed = true;
                        }
                        break;
                    case 'W':
                        if (inputHandler.pressings[W])
                        {
                            secondButtonScript.wasPressed = true;
                        }
                        break;
                    case 'E':
                        if (inputHandler.pressings[E])
                        {
                            secondButtonScript.wasPressed = true;
                        }
                        break;
                    case 'R':
                        if (inputHandler.pressings[R])
                        {
                            secondButtonScript.wasPressed = true;
                        }
                        break;
                    case 'U':
                        if (inputHandler.pressings[UP])
                        {
                            secondButtonScript.wasPressed = true;
                        }
                        break;
                    case 'I':
                        if (inputHandler.pressings[DOWN])
                        {
                            secondButtonScript.wasPressed = true;
                        }
                        break;
                    case 'O':
                        if (inputHandler.pressings[RIGHT])
                        {
                            secondButtonScript.wasPressed = true;
                        }
                        break;
                    case 'P':
                        if (inputHandler.pressings[LEFT])
                        {
                            secondButtonScript.wasPressed = true;
                        }
                        break;
                }
                if (secondButtonScript.wasPressed && secondButtonScript.hasScored == false)
                {
                    if (isOk)
                    {
                        theManager.score += 100;
                    }
                    else if (isPerf)
                    {
                        theManager.score += 1000;
                    }
                    secondButtonScript.hasScored = true;
                }
            }
        }
    }
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

    }
}

