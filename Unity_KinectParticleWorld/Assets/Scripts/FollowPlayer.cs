//-----------------------------------------
//   Jason Walters
//   http://glitchbeam.com
//   @jasonrwalters
//
//   Last edit on 9/26/2015
//-----------------------------------------

using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    private Transform tr;

    // Use this for initialization
    void Start()
    {
        // reference components
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // get player position
        // update x position with player x
        Vector3 pos = player.transform.position;
        tr.position = new Vector3(pos.x, tr.position.y, tr.position.z);
    }
}