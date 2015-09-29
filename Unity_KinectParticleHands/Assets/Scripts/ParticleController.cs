//-----------------------------------------
//   Jason Walters
//   http://glitchbeam.com
//   @jasonrwalters
//
//   last edit on 9/26/2015
//-----------------------------------------

using UnityEngine;
using System.Collections;

public class ParticleController : MonoBehaviour
{
    private Transform tr;
    private float camZ;

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
        // gets mouse position and converts to world units
        Vector2 mousePos = Input.mousePosition;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, camZ));

        // update position with new mouse world cordinates
        tr.position = mouseWorldPos;
    }
}