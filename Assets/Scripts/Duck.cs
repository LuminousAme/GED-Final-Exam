using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Duck : MonoBehaviour
{
    //the start and end of the duck's path
    private Vector2 spawn, end;
    //the speed at which it travels that path
    [SerializeField] private float speed = 1f;
    private float duration;
    private float currentTime; 

    //on enable is called when the duck is first spawned, even if was only disabled in the 
    private void OnEnable()
    {
        spawn = transform.position;

        end = new Vector2(spawn.x * -1.0f, 6.0f);

        duration = Mathf.Abs((end - spawn).magnitude) / speed;
        currentTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //calculate the position of the duck
        float t = Mathf.Clamp(currentTime / duration, 0.0f, 1.0f);
        transform.position = Vector3.Lerp(new Vector3(spawn.x, spawn.y, 2.0f), new Vector3(end.x, end.y, 2.0f), t);

        //update the currenttime
        currentTime += Time.deltaTime;

        //if the duck has finished it's path the game is over
        if(currentTime > duration)
        {
            //lose condition
            SceneManager.LoadScene("GameOverScreen");
        }
    }
}
