using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private float netOffset;

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
        netOffset = 0F;
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

        netOffset += offset - offsetErrorDegrade * Time.deltaTime;
        offset = 0F;

        // if the car is changing lanes, ignore weaving
        if (carCollider.IsTouching(centerDividerCollider))
        {
            netOffset = 0F;
        }

        // threshold for whether an incident is considered weaving
        if (netOffset > 3)
        {
            Debug.Log("Weaving Detected");
            netOffset = 0F;
        }
        else if (netOffset < 0)
        {
            netOffset = 0;
        }
    }

    public void isChangingLane()
    {
        netOffset = 0F;
    }
}

