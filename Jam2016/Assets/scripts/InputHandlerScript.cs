using UnityEngine;
using System.Collections;




public class InputHandlerScript : MonoBehaviour
{
    const int UP = 0;
    const int DOWN = 1;
    const int RIGHT = 2;
    const int LEFT = 3;
    const int Q = 4;
    const int W = 5;
    const int E = 6;
    const int R = 7;



    //ACCESOS DE TECLADO
    //Camera
    KeyCode _upKey = KeyCode.UpArrow;
    KeyCode _downKey = KeyCode.DownArrow;
    KeyCode _leftKey = KeyCode.LeftArrow;
    KeyCode _rightKey = KeyCode.RightArrow;
    KeyCode _wKey = KeyCode.W;
    KeyCode _qKey = KeyCode.Q;
    KeyCode _eKey = KeyCode.E;
    KeyCode _rKey = KeyCode.R;

    public bool aKeyPressedNext;
    public bool aKeyPressedSecond;
    public bool _pressingUp;
    public bool _pressingDown;
    public bool _pressingLeft;
    public bool _pressingRight;
    public bool _pressingQ;
    public bool _pressingW;
    public bool _pressingE;
    public bool _pressingR;

    public bool[] pressings = new bool[8];


    void Start() {


        aKeyPressedNext = aKeyPressedSecond = false;
    }

    void Update()
    {
        this.ResetKeys();
        this.CheckInput();
        this.UpdateArray();
        
    }

    private void UpdateArray() {
        pressings[UP] = this._pressingUp;
        pressings[DOWN] = this._pressingDown;
        pressings[LEFT] = this._pressingLeft;
        pressings[RIGHT] = this._pressingRight;
        pressings[Q] = this._pressingQ;
        pressings[R] = this._pressingE;
        pressings[E] = this._pressingR;
        pressings[W] = this._pressingW;
    }

    private void ResetKeys()
    {
  
        this._pressingUp = false;
        this._pressingDown = false;
        this._pressingLeft = false;
        this._pressingRight = false;
        this._pressingQ = false;
        this._pressingE = false;
        this._pressingR = false;
        this._pressingW = false;
        this.aKeyPressedNext = this.aKeyPressedSecond = false;
    }


    //Handles keyboard input
    void CheckInput()
    {
        #region Control
        if (Input.GetKeyDown(_upKey))
        {
            this._pressingUp = true;

            aKeyPressedNext = true;
        }

        if (Input.GetKeyDown(_downKey))
        {   
            this._pressingDown = true;
            aKeyPressedNext = true;
        }

        if (Input.GetKeyDown(_leftKey))
        {
            this._pressingLeft = true;
            aKeyPressedNext = true;
        }

        if (Input.GetKeyDown(_rightKey))
        {
            this._pressingUp = true;
            aKeyPressedNext = true;
        }

        if (Input.GetKeyDown(_qKey))
        {
            this._pressingQ = true;
            aKeyPressedSecond = true;
        }

        if (Input.GetKeyDown(_wKey))
        {
            this._pressingW = true;
            aKeyPressedSecond = true;
        }

        if (Input.GetKeyDown(_eKey))
        {
            this._pressingE = true;
            aKeyPressedSecond = true;
        }

        if (Input.GetKeyDown(_rKey))
        {
            this._pressingR = true;
            aKeyPressedSecond = true;
        }

        #endregion

    }
}
