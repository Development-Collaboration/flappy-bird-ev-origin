using UnityEngine;
using TMPro;


public class Score : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    private GameScore gameScore;

    [SerializeField]
    private int currentScore, highScore = 0;

    [SerializeField]
    private bool isDpHighScore = false;


    private void Awake()
    {
        gameScore = FindObjectOfType<GameScore>();
        scoreText = GetComponent<TextMeshProUGUI>();


    }
    private void OnEnable()
    {
        gameScore.SetScoreObject(this);
        DpScore();
    }

    public void DpScore()
    {
        currentScore = gameScore.CurrentScore;
        highScore = gameScore.HighScore;

        scoreText.text = gameScore.CurrentScore.ToString();

        if(isDpHighScore)
        {
            scoreText.text = gameScore.HighScore.ToString();

        }

    }



}
