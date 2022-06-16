using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class GameController : MonoBehaviour
{

    [SerializeField]
    private TMP_Text scoreLabel, scoreLabel2, scoreLabel3, livesLabel, bestScoreLabel, bestScoreLabel2, bestScoreLabel3;

    [SerializeField]
    private GameObject warningText, stageText;

    public Slider progressBar;
    public AudioMixer audioMixer;
    //public AudioScript audioScript;

    public static int score;
    public static int bestScore;

    private static string lives;

    public static bool gameOver = false;

    public static bool shield = false;

    public static bool bossFight = false;
    public static bool stopEmitter = false;
    public static bool stageComplete = false;

    private float timer2, timer1 = 0;



    public static void increaseScore(int increment)
    {
        score += increment;
    }

    public static void decreaseLives(int hearts)
    {
        if (shield == false)
        {
            if (lives.Length > 0)
            {
                lives = lives.Remove(lives.Length - hearts);
                if (lives.Length == 0)
                {
                    Debug.Log(lives.Length);
                    gameOver = true;
                    Debug.Log(gameOver);
                }
            }


        }
        else return;
    }

    public static void increaseLives()
    {
        if (lives.Length > 7)
        {
            return;
        }
        lives = lives.Insert(0, "♥");
    }

    private void Awake()
    {
        stageComplete = false;
        bossFight = false;
        stopEmitter = false;
        StartCoroutine(CrossFade.EndFade(audioMixer, "stage", 1, 1));
    }
    private void Start()
    {
        score = 0;
        lives = "♥♥♥";
    }

    void Update()
    {
        scoreLabel.text = "Score: " + score;
        scoreLabel2.text = scoreLabel3.text = " \n " + scoreLabel.text;
        progressBar.value = score;

        timer1 += Time.deltaTime;
        if (timer1 > 1.5f)
        {
            stageText.SetActive(false);
        }

        if (!stageComplete)
        {
            if (score >= 500)
            {
                stopEmitter = true;
                warningText.SetActive(true);
                progressBar.gameObject.SetActive(false);

                StartCoroutine(CrossFade.StartFade(audioMixer, "stage", 3, 0));
            }

            if (stopEmitter)
            {
                timer2 += Time.deltaTime;
                if (timer2 > 4)
                {
                    warningText.SetActive(false);
                    bossFight = true;
                    //audioMixer.SetFloat("boss", 1);

                }
            }
        }
        //else audioMixer.SetFloat("boss", 0);

        livesLabel.text = "" + lives;

        if ((gameOver || stageComplete) && bestScore < score)
        {
            //audioMixer.SetFloat("boss", 0);

            bestScore = score;
        }

        bestScoreLabel.text = "High score: \n" + bestScore;
        bestScoreLabel2.text = bestScoreLabel3.text = bestScoreLabel.text;
    }
}
