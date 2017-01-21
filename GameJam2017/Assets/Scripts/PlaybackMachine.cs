using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaybackMachine : MonoBehaviour {

    /** The Playback machine will be the object that the user places the sound blocks into
    *
    *   It is automatically sizable from the Sound block factory to fit how ever many sound blocks will be created
    *   It checks to make sure all sound all sound blocks have been fitted and will play them all back when a play button is pressed
    */

    private List<GameObject> BlockSpaces = new List<GameObject>();

    private bool BlocksFilled = false;
    private bool BlocksCorrect = false;


    [SerializeField]
    //Prefab of the Block Spaces
    private GameObject BlockSpacePrefab;

    void Update()
    {
        //Check the block spaces 
        BlocksFilled = true;
        BlocksCorrect = true;

        foreach (GameObject Block in BlockSpaces)
        {
            BlockSpace BlockSpaceScript = Block.GetComponent<BlockSpace>();

            if (!BlockSpaceScript.IsObjectSet())
            {
                BlocksFilled = false;
            }
            else if(!BlockSpaceScript.IsObjectSetAndCorrect())
            {
                BlocksCorrect = false;
            }
        }
    }

    public void SetUpPlaybackMachine(int NumberOfBlocks)
    {
        //Get The Length of Playback machine
        Vector3 Shape = Vector3.Scale(GetComponent<MeshFilter>().mesh.bounds.size,transform.localScale);
       
        Vector3 Centre = transform.localPosition;

        
        float Spacing = Shape.x / NumberOfBlocks;

        float Gap = 0.0f;

        for (int i = 1; i <= NumberOfBlocks; i++)
        {
            //Set up the block space position based on this and create them
            GameObject NewSpace = Instantiate(BlockSpacePrefab, Centre, transform.rotation);
            BlockSpace NewSpaceScript = NewSpace.GetComponent<BlockSpace>();
            NewSpaceScript.SetID(i-1);
           
            NewSpace.transform.Translate(new Vector3((Shape.x / 2) - (Spacing / 2) - Gap , 0, 0));

            Gap += Spacing;

            BlockSpaces.Add(NewSpace);
        }
    }

    public bool IsBlocksFilled()
    {
        return BlocksFilled;
    }

    public bool IsBlocksCorrect()
    {
        return BlocksCorrect;
    }


}
