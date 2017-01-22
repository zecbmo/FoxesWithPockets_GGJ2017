using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBlockFactory : MonoBehaviour {


    /**
     *  The Sound Block Factory
     * 
     *  This class takes a sound file and divides it by a given number amounts 
     *  It will create "Sound Blocks" that when played or listened to will only play the given sound
     *  Sound will be Set to a block based on the number of divisions
     *  
     *  e.g. so a sound file, 1 mintue long, that we want divided by 6 will create four blocks.
     *  The first block will start the audio at 0 and finish at 10 seconds
     *  The second will start at 10 seconds and finish at 20 and so on.
     *
     *  It will also set up the placback machine for these blocks - The Tape player
     */


    
  //  [SerializeField]
    //The Amount to divide up the audio file
    private int DivideAmount = 1;

   // [SerializeField]
    //The source audio clip to break up
    private AudioClip SourceAudioFile;

    [SerializeField]
    //This will be The object that will be created
    private GameObject SoundBlockPrefab;

  //  [SerializeField]
    //Reference to the playback machine that should be in the scene
    private GameObject PlaybackMachineObject;

    //Length of the audio file
    private float AudioLength;

    //How long each sample should be
    private float SampleSize;

    //List of new audio objects - can be spawned now in a random order
    private List<GameObject> SoundBlocks = new List<GameObject>();

    
    //Reference to the playback machine that should be in the scene
    [SerializeField]
    private float spawnRange;
    //private float xModifier;
    private Vector3 spawnPosition;

    // Use this for initialization
    void OnEnable ()
    {
        //if spawn range is 0, set a default
        if (spawnRange == 0) spawnRange = 1.0f;

        PlaybackMachineObject = FindObjectOfType<PlaybackMachine>().gameObject;
	}

    //take initialise function outside of start - allows us to store audioclips in a spawner rather than the individual character
    public void InitialiseBlocks(AudioClip myAudioClip, int myDivideAmount)
    {
        SourceAudioFile = myAudioClip;
        DivideAmount = myDivideAmount;
        //Get the audio length and set the smaple size
        AudioLength = SourceAudioFile.length;
        SampleSize = AudioLength / (float)DivideAmount;

        //x modifier is the range we want them to spawn in (
       // xModifier = spawnRange / myDivideAmount;

        //set initial spawn position to be the far left point
        spawnPosition = GameObject.Find("SoundSpawnPoint").transform.position;


        float AudioStartPoint = 0;
        float AudioEndPoint = SampleSize;

        for (int i = 1; i <= DivideAmount; i++)
        {
            if (i == DivideAmount)
            {
                AudioEndPoint = AudioLength;
            }

            //Create the AudioBlock Here and initialise it based on these Settings
            GameObject NewSoundBlock = Instantiate(SoundBlockPrefab, spawnPosition, Quaternion.identity);
            NewSoundBlock.SetActive(false);

       
            SoundBlock NewSoundScript = NewSoundBlock.GetComponent<SoundBlock>();
            NewSoundScript.SetUpAudio(SourceAudioFile, AudioStartPoint, AudioEndPoint, i - 1); //-1 to make it 0 - fixes problems later on for ID

            //Wait here?

            //Update Sample points for next object
            AudioStartPoint += SampleSize;
            AudioEndPoint += SampleSize;

            SoundBlocks.Add(NewSoundBlock);
        }

        //Set up the playback machine
        PlaybackMachine PlaybackMachineScript = PlaybackMachineObject.GetComponent<PlaybackMachine>();
        PlaybackMachineScript.SetUpPlaybackMachine(DivideAmount, SampleSize);

    }

    public void SpawnNextBlock()
    {

        int RandomBlock = Random.Range(0, SoundBlocks.Count);

        GameObject Block = SoundBlocks[RandomBlock];
        SoundBlocks.Remove(Block);

        Block.SetActive(true);
        //after we spawn a block, make the next spawn position increase by the x modifier
        Block.transform.position = spawnPosition;
        float xForce = Random.Range(-20.0f, 20.0f);
        Block.GetComponent<Rigidbody>().AddForce(xForce, 100, 50f);
        Block.GetComponent<AudioSource>().Play();

    }

    public bool SoundBlocksStillToSpawn()
    {
        if (SoundBlocks.Count == 0)
        {
            return false;
        }

        return true;
    }

    //public void SpawnBlocks()
    //{

    //    float AudioStartPoint = 0;
    //    float AudioEndPoint = SampleSize;

    //    for (int i = 1; i <= DivideAmount; i++)
    //    {
    //        if (i == DivideAmount)
    //        {
    //            AudioEndPoint = AudioLength;
    //        }

    //        //Create the AudioBlock Here and initialise it based on these Settings
    //        GameObject NewSoundBlock = Instantiate(SoundBlockPrefab, spawnPosition, Quaternion.identity);
    //        //after we spawn a block, make the next spawn position increase by the x modifier
    //        spawnPosition = gameObject.transform.position + new Vector3(xModifier,0);
    //        SoundBlock NewSoundScript = NewSoundBlock.GetComponent<SoundBlock>();
    //        NewSoundScript.SetUpAudio(SourceAudioFile, AudioStartPoint, AudioEndPoint, i - 1); //-1 to make it 0 - fixes problems later on for ID

    //        //Wait here?

    //        //Update Sample points for next object
    //        AudioStartPoint += SampleSize;
    //        AudioEndPoint += SampleSize;
    //    }

    //    //Set up the playback machine
    //    PlaybackMachine PlaybackMachineScript = PlaybackMachineObject.GetComponent<PlaybackMachine>();
    //    PlaybackMachineScript.SetUpPlaybackMachine(DivideAmount, SampleSize);
    //}
}
