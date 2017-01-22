using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryHandler : MonoBehaviour {

    [SerializeField] int divisionValue;

    [SerializeField] private AudioClip[] storyClips;

    [SerializeField]
    private string[] storyStrings;

    [SerializeField]
    private CharacterHandler[] myCharacters;

    [SerializeField]
    private GameObject[] answerGameobjects;

    private bool storyPlaying;

    private int currentCharacter = 0;
	
    void Start()
    {
        PlayStory();
    }
	// Update is called once per frame
	void Update () { 	

      
	}

    public void PlayStory()
    {
        if (!storyPlaying)
        {
            if ((storyStrings.Length == myCharacters.Length && storyStrings.Length == storyClips.Length) && answerGameobjects.Length != 0)
            {
                storyPlaying = true;
                InitialiseNewCharacters();
                SetWhiteBoard();
            }

            else
            {
                Debug.Log("The amount of strings/Characters/Clips need to be the same");
                Application.Quit();
            }
        }

        
    }

    public void ResetStory()
    {
        storyPlaying = false;
        currentCharacter = 0;
    }

    //initialise our characters audio files - splitting up the audio files and set the clips to the correct length
    //then we have the first character enter the scene
    private void InitialiseNewCharacters()
    {
        myCharacters[currentCharacter].InitialiseCharacter(storyClips[currentCharacter], divisionValue);
        myCharacters[currentCharacter].EnterScene();
    }

    //when a character leaves the scene, we move onto the next one. if we're on the last character, call finished characters
    public void NextCharacter()
    {
        currentCharacter += 1;

        if (currentCharacter > myCharacters.Length - 1)
        {
            FinishedCharacters();
        }
        else
        {
            myCharacters[currentCharacter].InitialiseCharacter(storyClips[currentCharacter], divisionValue);
            myCharacters[currentCharacter].EnterScene();
        }
    }

    private void SetWhiteBoard()
    {
        FindObjectOfType<Whiteboard>().SetupWhiteBoard(storyStrings);
    }

    private void FinishedCharacters()
    {
        for (int i = 0; i < answerGameobjects.Length; i++)
        {
            Instantiate(answerGameobjects[i], transform.position, Quaternion.identity);
        }
       
       // Debug.Log("THIS IS WHERE WE'LL ACTIVATE THE BIN");
    }
}
