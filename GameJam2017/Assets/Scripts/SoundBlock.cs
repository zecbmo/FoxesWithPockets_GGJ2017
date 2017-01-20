using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBlock : MonoBehaviour {


    private float AudioStartPoint;
    private float AudioEndPoint;
    private AudioSource Audio;


	
	
	// Update is called once per frame
	void Update ()
    {
        if (Audio.time > AudioEndPoint)
        {
            Audio.time = AudioStartPoint;
        }	
	}

    public void SetUpAudio(AudioClip Clip, float StartPoint, float EndPoint)
    {
        AudioStartPoint = StartPoint;
        AudioEndPoint = EndPoint;

        Audio = GetComponent<AudioSource>();

        Audio.clip = Clip;
        Audio.time = AudioStartPoint;
        Audio.Play();

    }

  
}
