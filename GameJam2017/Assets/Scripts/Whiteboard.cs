using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Whiteboard : MonoBehaviour
{
    private List<GameObject> Clues = new List<GameObject>();
    public GameObject TextCanvas;

    private int Counter = 0;

    void Start()
    {
        SetupWhiteBoard();

        PlaybackMachine.OnSegmentWin += RevealNextClue;
        

    }
    public void SetupWhiteBoard()
    {
        Vector3 Shape = Vector3.Scale(GetComponent<MeshFilter>().sharedMesh.bounds.size, transform.localScale);

        Vector3 Centre = transform.localPosition;

        int NumberOfClues = 6;
       
        float Spacing2 = 30.0f;
       
        float Gap = 0.0f;

        for (int i = 1; i <= NumberOfClues; i++)
        {

            GameObject NewObject = new GameObject();
           


            Text text = NewObject.AddComponent<Text>();
            text.text = "Fuck You!";

            RectTransform TextRect = NewObject.GetComponent<RectTransform>();
            TextRect.sizeDelta = new Vector2(500, 40);
            TextRect.localPosition = new Vector2(0.9f, 80 - Gap);
            TextRect.localScale = new Vector2(0.4f, 0.7f);


            Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
            text.font = ArialFont;
            text.material = ArialFont.material;
            text.color = new Color(0, 0, 0, 1);

            NewObject.transform.SetParent(TextCanvas.transform, false);

            Gap += Spacing2;

            NewObject.SetActive(false);

            Clues.Add(NewObject);

        }               
    }

    private void RevealNextClue()
    {
        if (Counter <= Clues.Count)
        {
            Clues[Counter].SetActive(true);
            Counter++;
        }
    }

   

}
