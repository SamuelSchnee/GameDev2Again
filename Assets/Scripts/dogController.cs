using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogController : MonoBehaviour
{
    public NewPetSwap petSwap;
    public GameObject dogStorage;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (petSwap.dogActive == false)
        {
            transform.position = dogStorage.transform.position;
        }

        if (petSwap.dogActive == true)
        {
            transform.position = player.transform.position;
        }
    }
}
