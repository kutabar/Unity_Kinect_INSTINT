//-----------------------------------------
//   Jason Walters
//   http://glitchbeam.com
//   @jasonrwalters
//
//   Last edit on 9/26/2015
//-----------------------------------------

using UnityEngine;
using System.Collections;

public class ParticleController : MonoBehaviour
{
    public float alphaMin;
    public float alphaMax;

    private ParticleSystem ps;

    // Use this for initialization
    void Start()
    {
        // reference components
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        // get body distance
        float distance = PlayerController.distance;

        // set playback speed by distance
        float speed = Mathf.Lerp(0.5f, 1.0f, Mathf.InverseLerp(0.0f, 1.0f, distance));
        ps.playbackSpeed = speed;

        // set alpha by distance
        float alpha = Mathf.Lerp(alphaMin, alphaMax, Mathf.InverseLerp(0.0f, 1.0f, distance));
        ps.startColor = new Color(1.0f, 1.0f, 1.0f, alpha);
    }
}