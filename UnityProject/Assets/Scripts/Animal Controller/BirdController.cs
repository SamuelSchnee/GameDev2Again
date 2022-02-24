using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public GameObject birdStorage;
    public GameObject player;
    public NewPetSwap petSwap;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = petSwap.horizontalInput;

        if (horizontalInput < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
        if (horizontalInput > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (petSwap.birdActive == false)
        {
            transform.position = birdStorage.transform.position;
        }

        if (petSwap.birdActive == true)
        {
            transform.position = player.transform.position;
        }
    }
}
