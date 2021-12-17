using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private static bool paused;

    [SerializeField] private GameObject pausePanel;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            paused = !paused;
            if(pausePanel != null)
            {
                pausePanel.SetActive(paused);
            }
        }
    }

    public static bool GetPaused()
    {
        return paused;
    }
}
