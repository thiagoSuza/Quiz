using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreProvider : MonoBehaviour
{
    public static ScoreProvider instance;


    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private int scoreCount;


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        scoreCount = 0;
        scoreText.text = scoreCount.ToString();
    }

    public void AddScore()
    {
       float add = (Timer.instance.currentTime/5);
        scoreCount += (int)(2 * add);
        scoreText.text = scoreCount.ToString();
    }

    public void SaveScore()
    {
        if(scoreCount > PlayerPrefs.GetInt("Highscore",0)) 
        {
            PlayerPrefs.SetInt("Highscore", scoreCount);
        }
    }
}
