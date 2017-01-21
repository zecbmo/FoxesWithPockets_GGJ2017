using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiPlayOnce : MonoBehaviour {

    void OnEnable()
    {
        Invoke("SetInactive", 4.75f);
    }

    void SetInactive()
    {
        this.gameObject.SetActive(false);
    }


}
