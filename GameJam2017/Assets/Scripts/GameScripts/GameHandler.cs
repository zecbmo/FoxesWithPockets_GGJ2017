using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour {

    [SerializeField]
    private StoryHandler[] stories;
    private int currentStory = 0;

    public GameObject ConfettiDone;

	// Use this for initialization
	void Start () {
        AnswerBin.OnGameWin += NewStory;
        NewStory();
        ConfettiDone.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void NewStory()
    {

        if (currentStory >= stories.Length)
        {
            Debug.Log("GameOver");
            ConfettiDone.SetActive(true);

            return;
        }
       

        Debug.Log("START NEW STORY" + currentStory);

        for (int i = 0; i < stories.Length; i++)
        {
            if (i == currentStory)
            {

                stories[i].gameObject.SetActive(true);
                stories[i].ResetStory();
                
            }
            else
            {
                stories[i].gameObject.SetActive(false);
            }
        }

        currentStory++;
    }
}
