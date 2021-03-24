using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    [SerializeField] private Timer timer;
    [SerializeField] private Text winText;
    [SerializeField] private Text timeValue;

    public void RedWins()
    {
        gameObject.SetActive(true);

        winText.text = "Red Wins!";
        winText.color = Color.red;

        timer.gameOver = true;
        timer.gameObject.SetActive(false);

        timeValue.text = timer.timerValue.ToString("0.0");
    }
    public void BlueWins()
    {
        gameObject.SetActive(true);

        winText.text = "Blue Wins!";
        winText.color = Color.blue;

        timer.gameOver = true;
        timer.gameObject.SetActive(false);

        timeValue.text = timer.timerValue.ToString("0.0");
    }
}
