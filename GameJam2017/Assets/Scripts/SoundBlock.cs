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

    public delegate void SoundBlockNearHead(AudioSource thisAudioSource);
    public static event SoundBlockNearHead onSoundBlockNearHead;

    public delegate void SoundBlockPutDown(AudioSource thisAudioSource);
    public static event SoundBlockPutDown onSoundBlockPutDown;

    private bool PlaySoundOnce;

    // Update is called once per frame
    void Update()
    {
        if (Audio.time > AudioEndPoint)
        {
            if (PlaySoundOnce)
            {
                Audio.Stop();
                PlaySoundOnce = false;
            }
            else
            {
                Audio.time = AudioStartPoint;
            }
        }


        if (Audio.time < AudioStartPoint)
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

    public int GetID()
    {
        return ID;
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Head"))
        {
            onSoundBlockNearHead(Audio);
            Debug.Log("DO SOMETHING ON NEAR HEAD");
        }       
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Head"))
        {
            onSoundBlockPutDown(Audio);
            Debug.Log("DO SOMETHING ON PUT DOWN");
        }
    }

    public void PlayOnce(float Delay)
    {
        PlaySoundOnce = true;
        Audio.time = AudioStartPoint;
        Audio.PlayDelayed(Delay);
    }
    

    

}
