using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class trackController : MonoBehaviour
{
    public float speed;
    Vector2 offset;
    public float Acceleration;
    public float Decceleration;
    public float MaxSpeed;
    public float DragDecceleration;
    float oldOffset = 0F;
    float drag = 0F;
    public Text textbox;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //to accelerate and decelerate we need to change the offset
        //offset should never be decreasing so we just keep updating oldOffset
        offset = new Vector2(0, oldOffset + speed);
        oldOffset = oldOffset + speed;
        //Debug.Log(oldOffset);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
        //this block of if statements gets the input from keyboard and decides to either accelerate,
        //decelerate or slow down due to drag (when youre not on the gas the car slows down so I tried to make this realistic.
        if (Input.GetKey("up"))
        {
            speed = speed + Acceleration * Time.deltaTime;
            if (speed >= MaxSpeed)
            {
                speed = MaxSpeed;
            }
        }


        else if (Input.GetKey("down"))
        {
            speed = speed - Decceleration * Time.deltaTime;
            if (speed <= 0)
            {
                speed = 0;
            }
        }
        else
        {
            drag = speed / MaxSpeed * DragDecceleration;
            speed = speed - drag * Time.deltaTime;
            if (speed <= 0)
            {
                speed = 0;
            }
        }
        //textbox.text = speed.ToString();
        // Debug.Log(speed);
    }



    public string getSpeed()
    {
        return "speed" + speed.ToString();
    }
}
