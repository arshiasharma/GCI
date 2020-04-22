using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// collision.cs - What happens when the car collides with different collision objcets?
//
public class collision : MonoBehaviour
{

    public GameObject eTracker;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Divider")
        {
            eTracker.GetComponent<weaving>().isChangingLane(); // score function for weaving tracker
            eTracker.GetComponent<laneChange>().isChangingLane(); // score function for laneChange tracker
        }
        if (collider.gameObject.tag == "Boundary")
        {
            eTracker.GetComponent<correctLane>().offRoading(); // score function for correctLane tracker
        }
    }
}
