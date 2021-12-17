using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    //delegate function and associated event for when a duck is hit
    public delegate void HitTarget(GameObject duck);
    public static event HitTarget hitDuck;

    private AudioSource gunshotSFX;

    public int maxShots = 4;
    private int shotsRemaining;
    [SerializeField] private Text shotsText;

    private void Start()
    {
        gunshotSFX = this.GetComponent<AudioSource>();
        shotsRemaining = maxShots;
        shotsText.text = "Shots: " + shotsRemaining;
    }

    // Update is called once per frame
    void Update()
    {
        if(!PauseManager.GetPaused())
        {
            //get the mouse position in world space
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //update the cursor position to follow it
            transform.position = mousePos;

            //check if they're clicking the left mouse button
            if (Input.GetMouseButtonDown(0))
            {
                //play the gunshot sound effect
                gunshotSFX.Play();
                shotsRemaining--;

                //do a raycast from the crosshair's position
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero);

                //check if it was a duck that was hit
                if (hit.collider && hit.collider.tag == "Duck")
                {
                    //invoke the event saying the duck was hit
                    hitDuck?.Invoke(hit.collider.gameObject);
                    shotsRemaining++;
                }

                //if you run out of shots game over
                if(shotsRemaining <= 0)
                {
                    //lose condition
                    SceneManager.LoadScene("GameOverScreen");
                }

                shotsText.text = "Shots: " + shotsRemaining;
            }
        }
    }
}
