using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnMusic : MonoBehaviour {

    public AudioSource Music;

    void toggleAudio()
    {
        if (Music.isPlaying)
            Music.Stop();
        else
            Music.Play();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
