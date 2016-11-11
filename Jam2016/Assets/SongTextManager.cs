using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class SongTextManager : MonoBehaviour {
    Text text;
    public string songName;
    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = songName;
    }

}
