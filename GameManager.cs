using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text clickForPlay;

    public AudioSource Music;

    public bool startPlay;

    public BeatScroll theBeat;

    public static GameManager instance;

    public int currentScore;
    public int score = 100;
    public int scoreGood = 120;
    public int scorePerfect = 150;

    public int multiplier;
    public int multiplierTracker;
    public int [] multiplierSelect;

    public Text scoreText;
    public Text speedText;

    public float normalHit;
    public float goodHit;
    public float perfectHit;
    public float missHit;

    public GameObject resultsDisplay;
    public Text normalText, goodText, perfectText, missText, rankText, finalScoreText;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        scoreText.text = "Score : 0";
        multiplier = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlay)
        {   
            if (Input.anyKeyDown)
            {
                startPlay = true;
                theBeat.Started = true;

                clickForPlay.enabled = false;
                Music.Play();
            }
        }
        else
        {
            if (!Music.isPlaying && !resultsDisplay.activeInHierarchy)
            {
                resultsDisplay.SetActive(true);

                normalText.text = "" + normalHit;
                goodText.text = goodHit.ToString();
                perfectText.text = perfectHit.ToString();
                missText.text = "" + missHit;

                string rankValue = "F";

                if (currentScore > 5000)
                {
                    rankValue = "D";
                    if (currentScore > 6000)
                    {
                        rankValue = "C";
                        if (currentScore > 7500)
                        {
                            rankValue = "B";
                            if (currentScore > 9000)
                            {
                                rankValue = "A";
                                if (currentScore > 11000)
                                {
                                    rankValue = "S";
                                }
                            }
                        }
                    }
                }

                rankText.text = rankValue;

                finalScoreText.text = currentScore.ToString();
            }
        }
    }
    public void Hit()
    {
    
        if (multiplier - 1 < multiplierSelect.Length)
        {
            multiplierTracker++;

            if (multiplierSelect[multiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                multiplier++;
            }
        }

        speedText.text = "Combo : x" + multiplier;

        //currentScore += score * multiplier;
        scoreText.text = "Score : " + currentScore;
    }
    public void NormalHit()
    {
        currentScore += score * multiplier;
        Hit();

        normalHit++;
    }
    public void GoodHit()
    {
        currentScore += scoreGood * multiplier;
        Hit();

        goodHit++;
    }
    public void PerfectHit()
    {
        currentScore += scorePerfect * multiplier;
        Hit();

        perfectHit++;
    }
    public void Miss()
    {
        multiplier = 1;
        multiplierTracker = 0;

        speedText.text = "multiplier : x" + multiplier;

        missHit++;
    }
    public void PlayAgain()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("Start");
        clickForPlay.enabled = true;
    }
}
