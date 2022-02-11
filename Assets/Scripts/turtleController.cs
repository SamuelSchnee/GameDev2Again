using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turtleController : MonoBehaviour
{
    public GameObject turtleStorage;
    public GameObject player;
    public NewPetSwap petSwap;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (petSwap.turtleActive == false)
        {
            transform.position = turtleStorage.transform.position;
        }

        if (petSwap.turtleActive == true)
        {
            transform.position = player.transform.position;
        }
    }
}
