using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool gameOver;
    public bool collectedGhost;
    public int score;
    public float timer;
    public TMP_Text scoreText;
    public TMP_Text timerText;
    public TMP_Text gameText;
    // Start is called before the first frame update
    void Start()
    {
        //Set scoreText to the gameObject Score Text
        scoreText = GameObject.Find("Score Text").GetComponent<TMP_Text>();
        //Set timerText to the gameObject timerText
        timerText = GameObject.Find("timerText").GetComponent<TMP_Text>();
        //Set gameText to the gameObject gameText
        gameText = GameObject.Find("gameText").GetComponent<TMP_Text>();
        gameText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        //Change scoreText to say "Ghosts Collected: " and the score
        scoreText.text = "Ghosts Collected: " + score;
        timer += Time.deltaTime;
        timerText.text = "Timer: " + timer;

        if (score < 1)
        {
            if (timer >= 30)
            {
                //Show a message that says "You didn't catch the ghost!"
                gameText.text = "You didn't catch the ghost!";
                //Remove the text from timerText
                timerText.text = "";
                //Remove the text from scoreText
                scoreText.text = "";
                //Set timer to 0
                timer = 0;
                //Set the gameOver bool to true
                gameOver = true;
            }
            else
            {
                //Show a message that says "Thanks for helping!"
                gameText.text = "Thanks for helping!";
                //Remove the text from timerText
                timerText.text = "";
                //Remove the text from scoreText
                scoreText.text = "";
                //Set timer to 0
                timer = 0;
                //Set the gameOver bool to true
                gameOver = true;
            }
        }

    }
}
