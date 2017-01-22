using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerBlock : MonoBehaviour {

    // Use this for initialization
    public bool CorrectAnswer = false;

    public string Text;

    void Start()
    {
        AnswerBin.OnGameWin += DestroyMe;
    }

    void DestroyMe()
    {
        AnswerBin.OnGameWin -= DestroyMe;
        Destroy(gameObject);
    }
}
