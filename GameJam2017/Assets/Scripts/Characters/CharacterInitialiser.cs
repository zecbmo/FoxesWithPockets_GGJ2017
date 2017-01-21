using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInitialiser : MonoBehaviour {

    [SerializeField] int divisionValue;

    [SerializeField] private AudioClip[] storyClips;

    [SerializeField]
    private CharacterHandler[] myCharacters;

    private int currentCharacter = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            PlayGame();
        }
	}

    public void PlayGame()
    {
        InitialiseNewCharacters();
    }

    private void InitialiseNewCharacters()
    {
        for (int i = 0; i < storyClips.Length; i++)
        {
            myCharacters[i].InitialiseCharacter(storyClips[i], divisionValue);
        }

        myCharacters[currentCharacter].EnterScene();
    }
}
