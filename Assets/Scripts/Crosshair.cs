using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    //delegate function and associated event for when a duck is hit
    public delegate void HitTarget();
    static event HitTarget hitDuck;

    // Update is called once per frame
    void Update()
    {
        //get the mouse position in world space
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //update the cursor position to follow it
        transform.position = mousePos;

        //check if they're clicking the left mouse button
        if (Input.GetMouseButtonDown(0))
        {
            //do a raycast from the crosshair's position
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero);

            if (hit.collider)
                Debug.Log(hit.collider.name);

            //check if it was a duck that was hit
            if (hit.collider && hit.collider.tag == "Duck")
            {
                //invoke the event saying the duck was hit
                hitDuck?.Invoke();
            }
        }
    }
}
