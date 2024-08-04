using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    
    
    public Image timerImg;
    float remaining_time;
    public float max_time=50.0f;
    public GameObject gameOver;

    
    void Start()
    {
        remaining_time = max_time;
    }

    // Update is called once per frame
    void Update()
    {
        if (remaining_time>0)
        {
            remaining_time -= Time.deltaTime;
            timerImg.fillAmount = remaining_time / max_time;
        }
        else
        {
            gameOver.SetActive(true);
            Time.timeScale = 0.0f;
        }
        
    }
}
