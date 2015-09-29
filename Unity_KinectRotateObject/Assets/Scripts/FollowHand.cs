//-----------------------------------------
//   Jason Walters
//   http://glitchbeam.com
//   @jasonrwalters
//
//   Last edit on 9/26/2015
//-----------------------------------------

using UnityEngine;
using System.Collections;
using Kinect = Windows.Kinect;

public class FollowHand : MonoBehaviour
{
    public float speed;
    public float easing;
    public int direction;

    private Kinect.HandState handState;
    private Transform tr;
    private Vector3 inputMove;
    private float angle;
    private float camZ;
    private float target;

    // Use this for initialization
    void Start()
    {
        // reference components
        tr = GetComponent<Transform>();

        // invert our camera's z position
        camZ = Camera.main.transform.position.z * -1;
    }

    // Update is called once per frame
    void Update()
    {
        // get kinect status from bodysourceview script
        bool kinectActive = BodySourceView.kinectActive;

        // based on kinect status...
        if (kinectActive)
        {
            // get hand position 
            Vector3 hand = BodySourceView.hand;
            inputMove = hand;

            // get hand state
            handState = BodySourceView.handState;

            // based on gesture, toggle rotation speed
            if (handState == Kinect.HandState.Closed || handState == Kinect.HandState.Lasso)
                target = speed;
            else
                target = 0f;
        }
        else
        {
            // gets mouse position and converts to world units
            Vector2 mousePos = Input.mousePosition;
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, camZ));

            // get mouse position 
            inputMove = mouseWorldPos;

            // based on mouse press, toggle rotation speed
            if (Input.GetButtonDown("Fire1"))
                target = speed;
            else if (Input.GetButtonUp("Fire1"))
            {
                target = 0f;
            }
        }

        // easing formula for rotation speed transition
        float targetAngle = target;
        float t = targetAngle - angle;
        // Mathf.Abs is absolute value
        // https://en.wikipedia.org/wiki/Absolute_value
        if (Mathf.Abs(t) > 0)
        {
            angle += t * easing;
        }

        // rotate object towards position
        tr.RotateAround(tr.position, new Vector3(inputMove.y * direction, -inputMove.x * direction, 0.0f), angle);
    }
}