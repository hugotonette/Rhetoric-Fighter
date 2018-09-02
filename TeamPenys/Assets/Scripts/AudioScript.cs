using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour {

    AudioSource myAudio;
    public GameObject objecto;

	// Use this for initialization
	void Start () {
        myAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!myAudio.isPlaying)
        {
            objecto.transform.gameObject.SetActive(true);
        }
	}
}
