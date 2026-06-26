using UnityEngine;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameover; 


    public Text HighestScore;
    public static int HighestScoreCount;

    private int score;

    public void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();
        Time.timeScale = 1f;
        player.enabled = true;
        playButton.SetActive(false);
        gameover.SetActive(false);

     }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;

        pipemovement[] pipes = FindObjectsOfType<pipemovement>();
        foreach (var pipe in pipes)
        {
            Destroy(pipe.gameObject);
        }
    }

    public void GameOver()
    {
        gameover.SetActive(true);
        playButton.SetActive(true);
        Pause();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void Update()
    {
        if (score >= HighestScoreCount)
        {
            HighestScoreCount = score;
            PlayerPrefs.SetInt("HighestScore", HighestScoreCount);
        }
        scoreText.text = "score:" + score;
        HighestScore.text = "Hi-Score:" + HighestScoreCount;
         

    }

    public void Start()
    {
        if(PlayerPrefs.HasKey("HighestScore"))
        {
            HighestScoreCount = PlayerPrefs.GetInt("HighestScore");
        }
    }
     

}
