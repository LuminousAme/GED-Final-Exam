using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeLimitManager : MonoBehaviour
{
    public float maxTime;
    private float timeRemaining;

    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = maxTime;
        timeText.text = "Time: " + ((int)timeRemaining).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(!PauseManager.GetPaused())
        {
            timeRemaining -= Time.deltaTime;
            timeText.text = "Time: " + ((int)timeRemaining).ToString();

            if(timeRemaining <= 0.0f)
            {
                //lose condition
                SceneManager.LoadScene("GameOverScreen");
            }
        }
    }
}
