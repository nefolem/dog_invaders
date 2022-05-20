using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{

    [SerializeField]
    private TMP_Text scoreLabel, scoreLabel2, livesLabel, bestScoreLabel, bestScoreLabel2;

    public static int score;
    public static int bestScore;

    private static string lives;
    
    public static bool gameOver = false;

    public static bool shield = false;


    public static void increaseScore(int increment)
    {
        score += increment;
    }

    public static void decreaseLives(int hearts)
    {
        if(shield == false)
        {
            lives = lives.Remove(lives.Length + hearts);
            if (lives.Length == 1)
            {
                gameOver = true;
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

    private void Start()
    {
        score = 0;
        lives = "♥♥♥";

    }

    void Update()
    {
        scoreLabel.text = "Score: " + score;
        scoreLabel2.text = " \n " + scoreLabel.text;
        
        livesLabel.text = "" + lives;

        if (bestScore < score)
        {
            bestScore = score;
        }

        bestScoreLabel.text = "Best score: \n" + bestScore;
        bestScoreLabel2.text = bestScoreLabel.text;
    }
}
