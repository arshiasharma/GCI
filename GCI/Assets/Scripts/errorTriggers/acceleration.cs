using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
// acceleration.cs - Is the car speeding up and slowing down too much?
//

// Error score is based on change in velocity

public class acceleration : MonoBehaviour
{
    public float errorDecaySpeed; // Amount of error score removed per second
    public float errorThreshold; // Error score threshold for declaring a dui
    private float currentError; // Error Score, as in velocity change

    public GameObject track;

    private float speed;
    private float deltaSpeed;

    // Start is called before the first frame update
    void Start()
    {
        deltaSpeed = 0F;
        speed = 0F;
        currentError = 0F;
    }

    // Update is called once per frame
    void Update()
    {
        // how much has the speed changed by?
        deltaSpeed = Mathf.Abs(speed - track.GetComponent<trackController>().speed);

        // set current speed
        speed = track.GetComponent<trackController>().speed;

        // reduce error score by decay rate
        currentError -= errorDecaySpeed * Time.deltaTime;
        if (currentError < 0)
        {
            currentError = 0;
        }

        // increase error score by change in velocity
        currentError += deltaSpeed;

        // if error score threshold is passed, notify console
        if (currentError > errorThreshold)
        {
            Debug.Log("Unstable Acceleration detected");
            currentError = 0;
        }
    }
}
