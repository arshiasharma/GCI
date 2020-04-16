using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void OnCollisionStay2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Divider")
        {
            eTracker.GetComponent<weaving>().isChangingLane();
        }
    }
}
