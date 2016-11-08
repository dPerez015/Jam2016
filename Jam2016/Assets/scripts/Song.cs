using UnityEngine;
using System.Collections;

public class Song : MonoBehaviour {

    public Note[] allButtons;
    private int size;

    void Start()
    {
        size = allButtons.Length;
    }

    int getSize() {
        return size;
    }

    //sprite

}
