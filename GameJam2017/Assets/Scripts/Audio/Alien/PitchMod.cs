using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PitchMod : MonoBehaviour {

    [SerializeField]
    AudioMixerGroup selectedGroup;

    [SerializeField]
    AudioMixer baseMixer;
    AudioSource mySource;

    float pitchMod;
	// Use this for initialization
	void Start () {
        mySource = GetComponent<AudioSource>();
        mySource.outputAudioMixerGroup = selectedGroup;
    }
	
	// Update is called once per frame
	void Update () {   
	}

    private void PitchModFunction()
    {
        pitchMod += Random.Range(0.04f, 0.1f);
        if (pitchMod > 2.0) pitchMod = 0.3f;

           baseMixer.SetFloat("alienPitch",pitchMod);
    }

    private bool randomBool() { return (Random.value > 0.5f); }
}
