using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
public class PlayButton : MonoBehaviour
{
    public GameObject PlaybackMachineObject;
    private PlaybackMachine PlaybackMachineScript;

    

    private void Start()
    {
        GetComponent<VRTK_Button>().events.OnPush.AddListener(handlePush);
        PlaybackMachineScript = PlaybackMachineObject.GetComponent<PlaybackMachine>();
    }

    

    private void handlePush()
    {
        //Button Pushed Event

        if (!PlaybackMachineScript.AreBlocksPlaying())
        {
            if (PlaybackMachineScript.IsBlocksFilled())
            {
                PlaybackMachineScript.PlaySoundBlocks();
            }

            //Gameover
            
        }

    }



}
