﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerBin : MonoBehaviour {

    public GameObject WinConfetti;
    public GameObject LoseConfetti;


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

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Answer"))
        {
            AnswerBlock Answer = other.gameObject.GetComponent<AnswerBlock>();

            if (Answer.CorrectAnswer)
            {
                Debug.Log("Game Won");
                WinConfetti.SetActive(true);
                OnGameWin();
            }
            else
            {
                Debug.Log("Game Lost");
                LoseConfetti.SetActive(true);
                OnGameLose();
            }
        }
    }

}
