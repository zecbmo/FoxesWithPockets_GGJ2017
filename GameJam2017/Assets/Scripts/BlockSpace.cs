using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpace : MonoBehaviour {

    /**
    *   The Block Space
    *   
    *   An Empty block- visualised by a faded sphere that will hold and monitor the order of Sound blocks within the tape deck
    *   The monitor wheter a block is in place and if it is in the corrent place
    *  
    */

    private bool ObjectSet = false;

    private GameObject FittedBlock = null;

    private int ID = 0;

    private int FittedBlockID = 0;

    public void SetID(int NewID)
    {
        ID = NewID;
    }

    public void SetFittedBlock(GameObject SoundBlock)
    {
        FittedBlock = SoundBlock;
        SoundBlock SoundBlockScript = FittedBlock.GetComponent<SoundBlock>();
        FittedBlockID = SoundBlockScript.GetID();

        ObjectSet = true;
    }

    public void RemoveFittedBlock()
    {
        if (FittedBlock)
        {
            //TODO: Pop Fitted block here
        }
        FittedBlock = null;
        ObjectSet = false;
    }

    public bool IsObjectSetAndCorrect()
    {
        if (FittedBlock) //Only returns true if the block Matches 
        {
            if (FittedBlockID != ID)
            {
                return false;
            }
        }
        return ObjectSet;
    }

    public bool IsObjectSet()
    {
        return ObjectSet;
    }

    public void PlayOnce(float Delay)
    {
        FittedBlock.GetComponent<SoundBlock>().PlayOnce(Delay);
    }

   
}
