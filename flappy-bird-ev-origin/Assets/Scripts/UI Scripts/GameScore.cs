using UnityEngine;
using TMPro;

public class GameScore : MonoBehaviour
{
    // [SerializeField] 
   //  private TextMeshProUGUI scoreText;
    public GameData gameData;

    private Score score;

    public bool IsNewHighScore { get; set; }    
    public void SetScoreObject(Score _score)
    {
        score = _score;
    }

    // [SerializeField] 
    // private int score = 0;
    // [SerializeField] 
    // private int highScore = 0;

    public int CurrentScore { get; set; }
    public int HighScore { get; set; }

    
    private void Awake()
    {
        //scoreText = GetComponent<TextMeshProUGUI>();
        score = FindObjectOfType<Score>();

        IsNewHighScore = false;
    }
    

    // Start is called before the first frame update
    void Start()
    {

        CurrentScore = 0;

        // highscore;
        LoadGameScore();

        //scoreText.text = CurrentScore.ToString();

    }

    public void IncreaseScore()
    {
        ++CurrentScore;

        if(CurrentScore > HighScore)
        {
            IsNewHighScore = true;

            HighScore = CurrentScore;
            SaveGameScore();

        }

        score.DpScore();



    }

    public void SaveGameScore()
    {
        SaveSystem.Save(this);
    }

    public void LoadGameScore()
    {
        GameData data = SaveSystem.Load() as GameData;
        HighScore = data.highScore;
    }





}