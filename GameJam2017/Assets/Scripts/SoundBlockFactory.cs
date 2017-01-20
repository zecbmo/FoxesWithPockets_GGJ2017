﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBlockFactory : MonoBehaviour {


    /**
     *  The Sound Block Factory
     * 
     *  This class takes a sound file and divides it by a given number amounts 
     *  It will create "Sound Blocks" that when played or listened to will only play the given sound
     *  Sound will be Set to a block based on the number of divisions
     *  
     *  e.g. so a sound file, 1 mintue long, that we want divided by 6 will create four blocks.
     *  The first block will start the audio at 0 and finish at 10 seconds
     *  The second will start at 10 seconds and finish at 20 and so on.
     */


    
    [SerializeField]
    //The Amount to divide up the audio file
    private int DivideAmount = 1;

    [SerializeField]
    //The source audio clip to break up
    private AudioClip SourceAudioFile;

    [SerializeField]
    //This will be The object that will be created
    private GameObject SoundBlockPrefab;

    //Length of the audio file
    private float AudioLength;

    //How long each sample should be
    private float SampleSize;

    // Use this for initialization
    void Start ()
    {
        if (DivideAmount <= 0)
        {
            Debug.Log("You Can't Divide by 0 : Please Set the Divide amount in the Sound block Factory");
            Application.Quit();
        }

        if (SourceAudioFile)
        {
            //Get the audio length and set the smaple size
            AudioLength = SourceAudioFile.length;
            SampleSize = AudioLength / (float)DivideAmount;

            float AudioStartPoint = 0;
            float AudioEndPoint = SampleSize;

            for (int i = 1; i <= DivideAmount; i++)
            {
                if (i == DivideAmount)
                {
                    AudioEndPoint = AudioLength;
                }

                //Create the AudioBlock Here and initialise it based on these Settings
                GameObject NewSoundBlock = Instantiate(SoundBlockPrefab);
                SoundBlock NewSoundScript = NewSoundBlock.GetComponent<SoundBlock>();
                NewSoundScript.SetUpAudio(SourceAudioFile, AudioStartPoint, AudioEndPoint);

                //Wait here?

                //Update Sample points for next object
                AudioStartPoint += SampleSize;
                AudioEndPoint += SampleSize;
                         

            }
        }

	}

}
