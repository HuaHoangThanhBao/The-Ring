using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreHandler : MonoBehaviour {

    public Text point;
    public Text highScore;
    public Text scoreTxt;

    public GameObject gameOverImg;
    public GameObject highScoreImg;
    public GameObject titile;
    public GameObject guide;
    public GameObject pointImg;
    public GameObject scoreImg;
    public Button replayButton;

    public PlayerHandle player;

    PlayerProcess playerProcess;

    int score = 0;

    private void Start()
    {
        SetUIOnBegin();
        LoadScore();
    }

    private void Update()
    {
        if (!player.variables.endGame)
        {
            ScoreControl();
        }
        else
        {
            SubmitHighScore(score);
            scoreTxt.text = score.ToString();
        }

        ControlUIWhenOnGame();
    }

    void SetUIOnBegin()
    {
        gameOverImg.SetActive(false);
        pointImg.SetActive(false);
        titile.SetActive(true);
        guide.SetActive(true);
        highScoreImg.SetActive(false);
        scoreImg.SetActive(false);
        replayButton.gameObject.SetActive(false);
    }

    void ControlUIWhenOnGame()
    {
        if (player.variables.startGame)
        {
            pointImg.SetActive(true);
            titile.SetActive(false);
            guide.SetActive(false);
            highScoreImg.SetActive(false);
            scoreImg.SetActive(false);
            replayButton.gameObject.SetActive(false);
        }
    }

    float timeDelay;

    public void UISetActive()
    {
        highScore.text = getHighScore().ToString();

        titile.SetActive(true);
        scoreImg.SetActive(true);
        gameOverImg.SetActive(true);
        highScoreImg.SetActive(true);
        pointImg.SetActive(false);
        replayButton.gameObject.SetActive(true);
    }

    void ScoreControl()
    {
        if (player.inputs.keyDown)
        {
            score++;
            point.text = ("" + score).ToString();
        }
    }

    void LoadScore()
    {
        playerProcess = new PlayerProcess();

        if(PlayerPrefs.HasKey("highScore"))
        {
            playerProcess.highScore = PlayerPrefs.GetInt("highScore");
        }
    }

    int getHighScore()
    {
        return playerProcess.highScore;
    }
    
    void SaveScore()
    {
        PlayerPrefs.SetInt("highScore", playerProcess.highScore);
    }

    void SubmitHighScore(int newScore)
    {
        if(newScore > playerProcess.highScore)
        {
            playerProcess.highScore = newScore;
            SaveScore();
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("CircleInTheAir");
    }
}
