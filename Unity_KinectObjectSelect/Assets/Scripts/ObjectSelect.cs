//-----------------------------------------
//   Jason Walters
//   http://glitchbeam.com
//   @jasonrwalters
//
//   Last edit on 9/27/2015
//-----------------------------------------

using UnityEngine;
using System.Collections;

public class ObjectSelect : MonoBehaviour
{
    private MeshRenderer rend;
    private Color col;
    private bool toggle;
    private float seconds;
    private float maxTime;

    // Use this for initialization
    void Start()
    {
        // reference components
        rend = GetComponent<MeshRenderer>();

        // max time is in seconds
        maxTime = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // timer - do something if seconds is less than max time
        if (seconds < maxTime)
        {
            // count up our timer with delta time
            seconds += Time.deltaTime;

            if (toggle)
                // lerp color to white
                col = Color.Lerp(col, Color.white, seconds);
            else
                // lerp color to black
                col = Color.Lerp(col, Color.black, seconds);
        }

        // update material color
        rend.material.color = col;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!toggle)
            toggle = true;
        else
            toggle = false;

        // reset timer to zero
        seconds = 0f;
    }
}
