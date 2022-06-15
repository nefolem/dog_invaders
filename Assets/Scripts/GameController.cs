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
    private GameObject warningText;

    public Slider progressBar;
    public AudioMixer audioMixer;
    public AudioScript audioScript;

    public static int score;
    public static int bestScore;

    private static string lives;

    public static bool gameOver = false;

    public static bool shield = false;

    public static bool bossFight = false;
    public static bool stopEmitter = false;
    public static bool stageComplete = false;

    private float timer = 0;


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

        if (!stageComplete)
        {
            if (score >= 500)
            {
                stopEmitter = true;
                warningText.SetActive(true);
                progressBar.gameObject.SetActive(false);

                StartCoroutine(CrossFade.StartFade(audioMixer, "vol1", 3, 0));
                audioScript.WarningSound();
            }

            if (stopEmitter)
            {
                timer += Time.deltaTime;
                if (timer > 4)
                {
                    warningText.SetActive(false);
                    bossFight = true;
                    audioScript.BossFightSound(true);

                }
            }
        }
        else audioScript.BossFightSound(false);

        livesLabel.text = "" + lives;

        if ((gameOver || stageComplete) && bestScore < score)
        {
            audioScript.BossFightSound(false);
            bestScore = score;
        }

        bestScoreLabel.text = "High score: \n" + bestScore;
        bestScoreLabel2.text = bestScoreLabel3.text = bestScoreLabel.text;
    }
}
