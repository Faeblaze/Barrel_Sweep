using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public Player player;

    public float timer = 60f;
    public int score;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI Timer;
    public TextMeshProUGUI Gems;

    private string timerFormat;


    // Use this for initialization
    void Start ()
    {
        timerFormat = Timer.text;
    }

    void Update()
    {
        Timer.text = string.Format(timerFormat, Mathf.FloorToInt(timer / 60F), Mathf.FloorToInt(timer % 60F).ToString().PadLeft(2, '0'));
        scoreText.text = "Score: " + score;

        if (timer > 0)
            timer -= Time.deltaTime;
        else
        {
            timer = 0F;
            player.Die();
        }
    }
}
