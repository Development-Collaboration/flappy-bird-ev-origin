using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Need for Save data (BinaryFormatter)
[System.Serializable]
public class GameData 
{
    public int score;
    public int highScore;


    //public float[] position;

    public GameData (GameScore gameScore)
    {
        score = gameScore.CurrentScore;
        highScore = gameScore.HighScore;

        // position = new float[3];
        
    }
    
}
