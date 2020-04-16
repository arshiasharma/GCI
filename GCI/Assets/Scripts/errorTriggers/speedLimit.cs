using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
// speedLimit.cs - Is the car driving too fast or too slow?
//

// Error score is based on time in seconds outside of the acceptable speed range

public class speedLimit : MonoBehaviour
{
    public float errorDecaySpeed; // Amount of error score removed per second
    public float errorThreshold; // Error score threshold for declaring a dui
    public float currentError; // Error Score

    public GameObject track;
    public float maxSpeed;
    public float minSpeed;

    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0F;
        currentError = 0F;
    }

    // Update is called once per frame
    void Update()
    {
        // set current speed
        speed = track.GetComponent<trackController>().speed;

        // reduce error score by decay rate
        currentError -= errorDecaySpeed * Time.deltaTime;
        if (currentError < 0)
        {
            currentError = 0;
        }

        // increase error score if speed is not sufficient
        if (speed > maxSpeed || speed < minSpeed)
            currentError += (1 + errorDecaySpeed) * Time.deltaTime;

        // if error score threshold is passed, notify console
        if (currentError > errorThreshold && speed > maxSpeed)
        {
            Debug.Log("Speeding detected");
            currentError = 0;
        }
        else if (currentError > errorThreshold && speed < minSpeed)
        {
            Debug.Log("Slow driving detected");
            currentError = 0;
        }
    }
}
