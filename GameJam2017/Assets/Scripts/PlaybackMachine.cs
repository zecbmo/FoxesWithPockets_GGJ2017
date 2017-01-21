using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaybackMachine : MonoBehaviour {

    private List<GameObject> BlockSpaces = new List<GameObject>();

    [SerializeField]
    //Prefab of the Block Spaces
    private GameObject BlockSpacePrefab;

    public void SetUpPlaybackMachine(int NumberOfBlocks)
    {
        //Get The Length of Playback machine
        Vector3 Shape = GetComponent<MeshFilter>().mesh.bounds.size;
        Vector3 Centre = transform.localPosition;

        
        float Spacing = Shape.x / NumberOfBlocks;

        float Gap = 0.0f;

        for (int i = 1; i <= NumberOfBlocks; i++)
        {
            //Set up the block space position based on this and create them
            GameObject NewSpace = Instantiate(BlockSpacePrefab, Centre, transform.rotation);

           
            NewSpace.transform.Translate(new Vector3((Shape.x / 2) - (Spacing / 2) - Gap , 0, 0));

            Gap += Spacing;
        }


    }    


}
