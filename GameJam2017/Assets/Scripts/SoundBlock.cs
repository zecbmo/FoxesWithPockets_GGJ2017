using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBlock : MonoBehaviour {

    /**
    *   The Sound Block
    *
    *   This Script is added to the interactable auido object (prefab)
    *   It works with the Sound Block Factory to set up the Audio listener and the time Settings of the clip
    */
    private float AudioStartPoint;
    private float AudioEndPoint;
    private AudioSource Audio;
    private int ID;
	
	
	// Update is called once per frame
	void Update ()
    {
        if (Audio.time > AudioEndPoint)
        {
            Audio.time = AudioStartPoint;
        }	
	}

    public void SetUpAudio(AudioClip Clip, float StartPoint, float EndPoint, int SoundBlockID)
    {
        AudioStartPoint = StartPoint;
        AudioEndPoint = EndPoint;
        ID = SoundBlockID;
        Audio = GetComponent<AudioSource>();

        Audio.clip = Clip;
        Audio.time = AudioStartPoint;
        Audio.Play();

    }

  
}
