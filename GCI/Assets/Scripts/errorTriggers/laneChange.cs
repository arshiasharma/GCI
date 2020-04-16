using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
// laneChange.cs - Is the car drifting or riding in between the lanes too much?
//

// Error score is based on time in seconds being on a lane divider

public class laneChange : MonoBehaviour
{

    public float errorDecaySpeed; // Amount of error score removed per second
    public float errorThreshold; // Error score threshold for declaring a dui

    private float currentError; // Error Score

    // Start is called before the first frame update
    void Start()
    {
        currentError = 0F;
    }

    // Update is called once per frame
    void Update()
    {
        currentError -= errorDecaySpeed * Time.deltaTime;
        if (currentError < 0)
        {
            currentError = 0;
        }

        if (currentError > errorThreshold)
        {
            Debug.Log("Improper lane changing detected");
            currentError = 0;
        }
    }

    // if its changing lanes, increase score by 1 per second
    public void isChangingLane()
    {
        currentError += (1 + errorDecaySpeed) * Time.deltaTime;
    }
}

