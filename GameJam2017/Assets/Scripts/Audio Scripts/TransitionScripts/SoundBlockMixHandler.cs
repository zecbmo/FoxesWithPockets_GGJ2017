using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundBlockMixHandler : MonoBehaviour {

    //default and active audio mixer groups
    [SerializeField] private AudioMixerGroup defaultGroup;
    [SerializeField] private AudioMixerGroup activeGroup;


    //default and active audio snapshots
    [SerializeField]
    private AudioMixerSnapshot defaultSnapShot;
    [SerializeField]
    private AudioMixerSnapshot activeSnapShot;

    // Use this for initialization
    void Start () {
        //add the events to happen when the cube is near the head
        SoundBlock.onSoundBlockNearHead += ChangeSnapShotForNearHead;
        SoundBlock.onSoundBlockPutDown += ChangeSnapShotForPuttingDown;
    }
    //These events are hooked to whenever the soundblock hits the head collider and change the active audio mixer group and snapshot for the audiosource
    private void ChangeSnapShotForNearHead(AudioSource thisAudioSource)
    {
        thisAudioSource.outputAudioMixerGroup = activeGroup;
        activeSnapShot.TransitionTo(1.0f);
        
    }

    private void ChangeSnapShotForPuttingDown(AudioSource thisAudioSource)
    {
        thisAudioSource.outputAudioMixerGroup = defaultGroup;

        //ADD IN CHECK TO SEE IF YOU STILL HAVE ONE NEAR YOUR HEAD (OR ARE LYING ON THE FLOOR
        defaultSnapShot.TransitionTo(1.0f);
    }
}
