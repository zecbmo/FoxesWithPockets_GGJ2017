using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour {

    [SerializeField]
    private StoryHandler[] stories;
    private int currentStory;

	// Use this for initialization
	void Start () {
        AnswerBin.OnGameWin += NewStory;
        NewStory();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void NewStory()
    {
     
        currentStory = (int)Random.Range(0, stories.Length);

        Debug.Log("START NEW STORY" + currentStory);

        for (int i = 0; i < stories.Length - 1; i++)
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
    }
}
