using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DuckSpawner : MonoBehaviour
{
    [SerializeField] private GameObject duckPrefab;
    private List<GameObject> duckPool = new List<GameObject>();
    [SerializeField] private int totalNumOfDucks = 10;
    private int ducksHit = 0; //when the ducks left is equal or greater than the total number play the win condition
    [SerializeField] private int numOfDucksAtATime = 2;

    //oberserver pattern, link the duckhit function up with the event, the => is just a shorthand for a one line function
    private void OnEnable() => Crosshair.hitDuck += DuckHit;
    private void OnDisable() => Crosshair.hitDuck -= DuckHit;

    // Start is called before the first frame update
    void Start()
    {
        //create a number of ducks
        for(int i = 0; i < numOfDucksAtATime; i++)
        {
            GameObject newDuck = Instantiate(duckPrefab, new Vector3(0.0f, 0.0f, 2.0f), Quaternion.identity);
            newDuck.SetActive(false);
            duckPool.Add(newDuck);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //check if all the ducks are inactive 
        bool allInactive = true;
        foreach(GameObject duck in duckPool)
        {
            if(duck.activeInHierarchy)
            {
                allInactive = false;
                break;
            }
        }

        //if all the ducks are inactive than spawn some new ducks
        if(allInactive)
        {
            foreach(GameObject duck in duckPool)
            {
                //set a random position for the new duck
                float randX = Random.Range(-8.0f, 8.0f);
                duck.transform.position = new Vector3(randX, -6.0f, 2.0f);

                //set the duck to be active
                duck.SetActive(true);
            }
        }
    }

    //obeserve for when a duck is hit
    void DuckHit(GameObject duck)
    {
        //set the duck to be inactive
        duck.SetActive(false);
        //increase the number of ducks that have been hit
        ducksHit++;

        //if that number is equal or greater than the total number than end the game
        if(ducksHit >= totalNumOfDucks)
        {
            //win condition
            SceneManager.LoadScene("WinScreen");
        }
    }
}
