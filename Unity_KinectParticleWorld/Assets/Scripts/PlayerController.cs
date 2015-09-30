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

public class PlayerController : MonoBehaviour
{
    public static float distance;
    
    public float boundsX;
    public float speed;
    public float tilt;
    public float distanceMin;
    public float distanceMax;

    private Rigidbody rb;
    private Vector3 input;

    void Start()
    {
        // reference components
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // grabs input in update loop for best accuracy
        PlayerInput();
    }

    void FixedUpdate()
    {
        // run movement function to handle rigidbody physics
        Movement();
    }

    void PlayerInput()
    {
        if (BodySourceView.kinectActive)
        {
            // fetch hand positions
            Vector3 handLeft = BodySourceView.jointObjs[(int)Kinect.JointType.HandLeft].position;
            Vector3 handRight = BodySourceView.jointObjs[(int)Kinect.JointType.HandRight].position;
            Vector3 spineMid = BodySourceView.jointObjs[(int)Kinect.JointType.SpineMid].position;

            // calc angle of hands
            float angle = Mathf.Atan2(handRight.y - handLeft.y, handRight.x - handLeft.x) * Mathf.Rad2Deg;

            // convert angle rotation to movement values
            float x = Mathf.Lerp(-1.0f, 1.0f, Mathf.InverseLerp(-45.0f, 45.0f, angle));
            input = new Vector3(x, 0.0f, 0.0f);

            // body distance
            distance = Mathf.Lerp(-1.0f, 1.0f, Mathf.InverseLerp(distanceMin, distanceMax, spineMid.z));
        }
        else
        {
            // fetch our input for movememnt
            float x = Input.GetAxis("Horizontal");
            input = new Vector3(x, 0.0f, 0.0f);

            distance = Input.GetAxis("Vertical");
        }
    }

    void Movement()
    {
        // update player velocity
        rb.velocity = input * speed;

        // apply tilt effect to our rotation
        float tiltZ = rb.velocity.x * -tilt;
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, tiltZ);
    }
}