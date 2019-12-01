using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public static int score = 0;
    int prevScore = 0;
    // Score to display
    public Text scoreText;
    private void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = "Score: 0";
    }
    // Update is called once per frame
    void Update()
    {
        if (score != prevScore)
        {
            scoreText.text = "Score: " + score.ToString();
            prevScore = score;
        }

    }
}
