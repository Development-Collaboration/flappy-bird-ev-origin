using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrigianlEndlessSceneManager : MonoBehaviour
{

    private float originalEndlessGame_RestPlayingTime;

    public float OriginalEndlessGame_RestPlayingTime
    {
        get { return originalEndlessGame_RestPlayingTime; }
        set { originalEndlessGame_RestPlayingTime = value; }
    }

    private void Start()
    {
        //originalEndlessGame_RestPlayingTime = 0f;

    }

    private void FixedUpdate()
    {

        //originalEndlessGame_RestPlayingTime += Time.deltaTime;

        //print("originalEndlessGame_RestPlayingTime: " + originalEndlessGame_RestPlayingTime);

    }


}
