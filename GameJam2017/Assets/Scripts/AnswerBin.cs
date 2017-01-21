using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerBin : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public delegate void GameWin();
    public static event GameWin OnGameWin;

    public delegate void GameLose();
    public static event GameLose OnGameLose;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Answer"))
        {
            AnswerBlock Answer = other.gameObject.GetComponent<AnswerBlock>();

            if (Answer.CorrectAnswer)
            {
                OnGameWin();
            }
            else
            {
                OnGameLose();
            }
        }
    }

}
