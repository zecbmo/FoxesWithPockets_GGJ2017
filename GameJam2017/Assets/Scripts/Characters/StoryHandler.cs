using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryHandler : MonoBehaviour {

    [SerializeField] int divisionValue;

    [SerializeField] private AudioClip[] storyClips;

    [SerializeField]
    private CharacterHandler[] myCharacters;

    private int currentCharacter = 0;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            PlayStory();
        }
	}

    public void PlayStory()
    {
        InitialiseNewCharacters();
    }

    public void ResetStory()
    {
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

    private void FinishedCharacters()
    {
       
        Debug.Log("THIS IS WHERE WE'LL ACTIVATE THE BIN");
    }
}
