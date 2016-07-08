using UnityEngine;
using System.Collections;

public class buttonsound : MonoBehaviour {

	// Use this for initialization

	void Start () {
	
	}

    public void playsound()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
