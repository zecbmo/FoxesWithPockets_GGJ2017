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

    private AudioSource myAudioSource;
	// Use this for initialization
	void Start () {
        thisSpawner = GetComponentInChildren<SoundBlockFactory>();
        myAudioSource = GetComponentInChildren<AudioSource>();
        interviewPosition = interviewPositionTransform.position;
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftControl) && !movingIn)
        {
            movingIn = true;
            EnterScene();
            Debug.Log("ENTERING SCENE");
        }

        if (Input.GetKey(KeyCode.RightControl) && !leavingScene)
        {
            leavingScene = true;
            BeginExitScene();
            Debug.Log("LEAVE SCENE");
        }
    }


    public void InitialiseCharacter(AudioClip thisAudio,int divisions)
    {
        thisSpawner.InitialiseBlocks(thisAudio, divisions);
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
        LeanTween.rotateY(this.gameObject,180.0f, 0.8f).setEase(LeanTweenType.easeInOutQuad).setOnComplete(LeaveScene);
        
    }

    private void PlayAlienSpeak()
    {
        myAudioSource.Play();
        thisSpawner.SpawnBlocks();
    }

    //
    private void OnSceneEntered()
    {
        PlayAlienSpeak();
    }

    private void LeaveScene()
    {
    LeanTween.move(this.gameObject, startPosition, 2.0f).setEase(LeanTweenType.easeInOutQuad);
    }
}
