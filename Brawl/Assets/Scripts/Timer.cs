using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [HideInInspector] public bool gameOver = false;
    [HideInInspector] public float timerValue = 0;
    private Text timerText;
    void Start()
    {
        timerText = GetComponent<Text>();
    }

    void Update()
    {
        if (!gameOver)
        {
            timerValue += Time.deltaTime;
            timerText.text = timerValue.ToString("0.0");
        }
    }
}
