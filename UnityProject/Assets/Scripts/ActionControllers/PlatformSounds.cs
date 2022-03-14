using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSounds : MonoBehaviour
{

    public AudioClip woodFalling;
    private AudioSource plankAudio;
    private Rigidbody2D woodRB;

    // Start is called before the first frame update
    void Start()
    {
        plankAudio = GetComponent<AudioSource>();
        woodRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
