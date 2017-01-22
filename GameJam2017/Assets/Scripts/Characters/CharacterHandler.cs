using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHandler : MonoBehaviour {

    private SoundBlockFactory thisSpawner;
 
    private Vector3 startPosition;
    [SerializeField]
    Transform interviewPositionTransform;
    private Vector3 interviewPosition;

    private bool active;
    private int characterNumber;

    private bool movingIn;
    private bool leavingScene;

    private int numberOfDivisions = 0;

    private AudioSource myAudioSource;
	// Use this for initialization
	void Awake () {
        thisSpawner = GetComponentInChildren<SoundBlockFactory>();
        myAudioSource = GetComponentInChildren<AudioSource>();
        interviewPosition = interviewPositionTransform.position;
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
    }


    public void InitialiseCharacter(AudioClip thisAudio,int divisions)
    {
        thisSpawner.InitialiseBlocks(thisAudio, divisions);
        numberOfDivisions = divisions;
    }

    public void EnterScene()
    {
        //when we enter the scene, tie the playback machines win event to the character leaving
        PlaybackMachine.OnSegmentWin += BeginExitScene;
        LeanTween.move(this.gameObject, interviewPosition, 2.0f).setEase(LeanTweenType.easeOutQuad).setOnComplete(OnSceneEntered);
    }

    public void BeginExitScene()
    {
        //when this function is called, remove the event so it's no longer attached to this object
        PlaybackMachine.OnSegmentWin -= BeginExitScene;
        LeanTween.rotateY(this.gameObject,180.0f, 0.8f).setEase(LeanTweenType.easeInOutQuad).setOnComplete(BeginLeavingScene);
        
    }

    private void PlayAlienSpeak()
    {
        Debug.Log("ENTERED  SCENE");
        myAudioSource.Play();
        StartCoroutine(StartMethod(myAudioSource.clip.length/(float)numberOfDivisions));
    }

    

    private IEnumerator StartMethod(float clipLength)
    {

        
        yield return new WaitForSeconds(clipLength);
        Debug.Log("SPAWING NEXT BLOCK");
        thisSpawner.SpawnNextBlock();

        if (thisSpawner.SoundBlocksStillToSpawn())
        {
            StartCoroutine(StartMethod(clipLength));
        }

    }
    
    //these callback functions are for activating text/movement after tweens

    private void OnSceneEntered()
    {
        PlayAlienSpeak();
    }

    private void BeginLeavingScene()
    {
    LeanTween.move(this.gameObject, startPosition, 2.0f).setEase(LeanTweenType.easeInOutQuad).setOnComplete(LeftScene);
    }

    //when they've left, put the next character into the scene
    private void LeftScene() { GetComponentInParent<StoryHandler>().NextCharacter();}
}
