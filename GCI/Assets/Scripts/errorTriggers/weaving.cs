using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
// weaving.cs - Is the car turning frequently on a straightaway for no reason?(not changing lanes)
//

// Error score based on seconds spent turning without changing lanes

public class weaving : MonoBehaviour
{

    public GameObject carObject;
    Transform carTransform;
    Vector3 position;
    private BoxCollider2D carCollider;

    public GameObject centerDivider;
    private BoxCollider2D centerDividerCollider;

    public float offsetErrorDegrade; // How fast does the error score recover? High means that shift history will be ignored
    private float offset;
    private float errorScore;

    // Start is called before the first frame update
    void Start()
    {
        // car objects
        carTransform = carObject.transform;
        position = carTransform.position;
        carCollider = carObject.GetComponent<BoxCollider2D>();

        // divider objects
        centerDividerCollider = centerDivider.GetComponent<BoxCollider2D>();

        offset = 0F;
        errorScore = 0F;
    }

    // Update is called once per frame
    void Update()
    {
        // figure out how much the car is shifting by
        offset = carTransform.position.x - position.x;
        position = carTransform.position;

        if (offset < 0)
        {
            offset *= -1;
        }

        errorScore += offset - offsetErrorDegrade * Time.deltaTime;
        offset = 0F;

        // threshold for whether an incident is considered weaving
        if (errorScore > 3)
        {
            Debug.Log("Weaving Detected");
            errorScore = 0F;
        }
        else if (errorScore < 0)
        {
            errorScore = 0;
        }
    }

    // if the car is changing lanes, ignore the offset score
    public void isChangingLane()
    {
        errorScore = 0F;
    }
}

