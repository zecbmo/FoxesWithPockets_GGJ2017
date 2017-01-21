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

    //for playing blocks
    private int NumberOfBlocks = -1;
    bool IsBlocksPlaying = false;
  
    private float ClipLenght = 0;
    private float TotalClipLenght = 0;


    public delegate void SegmentWin();
    public static event SegmentWin OnSegmentWin;

    [SerializeField]
    //Prefab of the Block Spaces
    private GameObject BlockSpacePrefab;


    [SerializeField]
    //Confetti Game Object
    private GameObject Confetti;

  

    void Update()
    {
        //Check the block spaces 

        if (BlockSpaces.Count != 0)
        {
            BlocksFilled = true;
            BlocksCorrect = true;

            foreach (GameObject Block in BlockSpaces)
            {
                BlockSpace BlockSpaceScript = Block.GetComponent<BlockSpace>();

                if (!BlockSpaceScript.IsObjectSet())
                {
                    BlocksFilled = false;
                }

                if (!BlockSpaceScript.IsObjectSetAndCorrect())
                {
                    BlocksCorrect = false;
                }
            }
        }

     

    }

    public void SetUpPlaybackMachine(int NumberOfSoundBlocks, float SoundClipLength)
    {
        

        //Get The Length of Playback machine
        Vector3 Shape = Vector3.Scale(GetComponent<MeshFilter>().sharedMesh.bounds.size,transform.localScale);
       
        Vector3 Centre = transform.localPosition;
        NumberOfBlocks = NumberOfSoundBlocks;
        
        float Spacing = Shape.x / NumberOfSoundBlocks;

        float Gap = 0.0f;

        for (int i = 1; i <= NumberOfSoundBlocks; i++)
        {
            //Set up the block space position based on this and create them
            GameObject NewSpace = Instantiate(BlockSpacePrefab, Centre, transform.rotation);
            BlockSpace NewSpaceScript = NewSpace.GetComponent<BlockSpace>();
            NewSpaceScript.SetID(i-1);
           
            NewSpace.transform.Translate(new Vector3((Shape.x / 2) - (Spacing / 2) - Gap , 0, 0));

            Gap += Spacing;


            //AddBlockToList(NewSpace);
            BlockSpaces.Add(NewSpace);
            //Debug.Log("BlockSpaces size: " + BlockSpaces.Count.ToString());
        }

        ClipLenght = SoundClipLength;
        TotalClipLenght = SoundClipLength * NumberOfBlocks +0.2f; //Add a minor delay to the end - a small pause between being able to hit play again

    }

    public bool IsBlocksFilled()
    {
        return BlocksFilled;
    }

    public bool IsBlocksCorrect()
    {
        return BlocksCorrect;
    }



    public void PlaySoundBlocks()
    {
        IsBlocksPlaying = true;
     
        //Start the first block playing
        float Delay = 0;

        foreach (GameObject Block in BlockSpaces)
        {
            BlockSpace BlockSpaceScript = Block.GetComponent<BlockSpace>();
            BlockSpaceScript.PlayOnce(Delay);
            Delay += ClipLenght;
        }

        Invoke("SetPlayingAsFalseAndCheckWin", TotalClipLenght);
        
    }

    private void SetPlayingAsFalseAndCheckWin()
    {
        IsBlocksPlaying = false;
        
        if (BlocksCorrect)
        {
            //You win
            OnSegmentWin();

            Confetti.SetActive(true);
            //Play Audio Clip

        }
    }

    public bool AreBlocksPlaying()
    {
        return IsBlocksPlaying;
    }

    void AddBlockToList(GameObject Block)
    {

        if (!BlockSpaces.Contains(Block))
        {
            BlockSpaces.Add(Block);
        }
    }

}
