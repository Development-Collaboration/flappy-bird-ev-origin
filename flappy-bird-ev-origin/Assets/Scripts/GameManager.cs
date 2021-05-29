using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;  //

public class GameManager : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 2f;
    [SerializeField] private float startingContinueCountdownTime = 10f;
 
    public float ScrollingSpeed
    {
        get { return scrollSpeed; }
        set { scrollSpeed = value; }
    }

    public float StartingContinueCountdownTime
    {
        get { return startingContinueCountdownTime; }
        set { startingContinueCountdownTime = value; }
    }

    public enum GameStatus { Openning, Ready, Play, GameOver , Pause}
    public GameStatus gameStatus { get; set; }

    // Background Sprites Change
    [Header("Background Sprites")]
    [SerializeField] private bool morning;

    public bool IsItMorning { get { return morning;  } set { morning = value; } }

    public enum TimesOfDay { Dawn, Morning, Noon, Afternoon, Evening, Night }
    private TimesOfDayController timesOfDayController;

    private OrigianlEndlessSceneManager origianlEndlessSceneManager;

    private float totalGamePlayingTime;
    public float TotalGamePlayingTime
    {
        get { return totalGamePlayingTime; }
    }

    public static GameManager instance = null;

    private CountdownController countdownController;

    private const int frameRate = 30;

    public bool IsGamePause { get; set; }


    private GameScore gameScore;

    private PanelCtrl panelCtrl;
    private SceneLoader sceneLoader;

    private float continueHoldTime = 15;

    private AdmobManager admobManager;

    void Awake()
    {
        gameStatus = GameStatus.GameOver;

        instance = this;
        Application.targetFrameRate = frameRate;

        sceneLoader = FindObjectOfType<SceneLoader>();

        IsGamePause = false;
        
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        

        panelCtrl = FindObjectOfType<PanelCtrl>();
        panelCtrl.PanelAllSwtich(true);

        // objects 로 수정히지
        //gameScore = FindObjectOfType<GameScore>();

        //gameScore = FindObjectsOfType(typeof(GameScore)) as GameScore[];

        gameScore = GetComponent<GameScore>();

        countdownController = FindObjectOfType<CountdownController>();


        //
        origianlEndlessSceneManager = FindObjectOfType<OrigianlEndlessSceneManager>();

        //
        RandomBackgroundSelection();

        timesOfDayController = FindObjectOfType<TimesOfDayController>();


        admobManager = FindObjectOfType<AdmobManager>();
    }

    private void RandomBackgroundSelection()
    {
        float randNumber = Random.Range(0f, 1f);

        if (randNumber > .5f)
        {
            morning = true;
        }
        else
        {
            morning = false;
        }
    }

    private void Start()
    {
        gameStatus = GameManager.GameStatus.Openning;
        panelCtrl.PanelSwitch(gameStatus);
    }

    private void FixedUpdate()
    {
        // Time.time ; Goes up by seconds
        //totalGamePlayingTime = Time.realtimeSinceStartup;

        //print("totalGamePlayingTime: " + totalGamePlayingTime);

    }

    // Update is called once per frame
    void Update()
    {
        // Time Ctrl
        /*
        Time.timeScale = timeSpeed;
        Time.fixedDeltaTime = (0.02f * Time.timeScale);
        */

        if (gameStatus == GameManager.GameStatus.Ready 
            && (Input.GetButtonDown("Fire1")))
        {

            GamePlay();
        }

    }


    public void IncreaseScore()
    {
        gameScore.IncreaseScore();

        /*
        if((int)GameManager.Status.GameOver == gameStatus)
        {
            foreach (GameScore score in gameScore)
            {
                score.IncreaseScore();
            }

        }
        */


    }

    public void GameReady()
    {
        gameStatus = GameManager.GameStatus.Ready;
        panelCtrl.PanelSwitch(gameStatus);

    }

    public void GamePlay()
    {
        gameStatus = GameManager.GameStatus.Play;
        panelCtrl.PanelSwitch(gameStatus);

        timesOfDayController.LightMove();

    }


    public void GameRestart()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        sceneLoader.GameRestart();
        GameReady();
    }

    public void PauseButton()
    {
        if (!IsGamePause)
            PauseGame();
        else
            ResumeGame();
 
    }

    private void PauseGame()
    {
        IsGamePause = true;

        // timescale 0 == pause, 1 == default time
        // if timescale changes, chage fixedDeltatime too
        Time.timeScale = 0f;
        //Time.fixedDeltaTime = Time.timeScale;

        panelCtrl.menuPanel.SetActive(true);       

    }

    private void ResumeGame()
    {
        IsGamePause = false;

        Time.timeScale = 1f;
        //Time.fixedDeltaTime = Time.timeScale;

        panelCtrl.menuPanel.SetActive(false);

    }

    public void ContinueGame()
    {

        countdownController.StopContinueCountDown();

        gameStatus = GameManager.GameStatus.Play;
        panelCtrl.PanelSwitch(gameStatus);

    }


    public void PlayerDied(bool isContinuable)
    {
        gameStatus = GameManager.GameStatus.GameOver;
        panelCtrl.PanelSwitch(gameStatus);

        if(isContinuable)
        {
            countdownController.SetContinueCountDown();
        }
        else
        {
            countdownController.EndContinue();
        }

    }

    public void OnPlayRewardedAd()
    {
        admobManager.PlayRewardedAd();
    }




}
