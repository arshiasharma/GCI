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
    public float DragCap; // The max speed reachable due to drag
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
        offset = new Vector2(0, oldOffset + (float)(speed*0.0002));
        oldOffset = oldOffset + (float)(speed * 0.0002);
        //Debug.Log(oldOffset);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
        
            // Up Arrow -> Constant Acceleration
        if (Input.GetKey("up"))
        {
            speed = speed + Acceleration * Time.deltaTime;
            if (speed >= MaxSpeed)
            {
                speed = MaxSpeed;
            }
        }

            // Down Arrow -> Constant deceleration
        else if (Input.GetKey("down"))
        {
            speed = speed - Decceleration * Time.deltaTime;
            if (speed <= 0)
            {
                speed = 0;
            }
        }

        // Regardless of control, apply a drag based on current speed over max speed. This will be a more realistic way to cap the max speed
        drag = (speed / DragCap) * Acceleration;
        speed = speed - drag * Time.deltaTime;
        if (speed <= 0)
        {
            speed = 0;
        }

        // Update the MPH textbox with correct speed
        textbox.text = Mathf.Round(speed).ToString();

    }




    public string getSpeed()
    {
        return "speed" + speed.ToString();
    }
}
