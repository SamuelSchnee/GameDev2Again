using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardController1 : MonoBehaviour
{
    public GameObject lizardStorage;
    public GameObject player;
    public NewPetSwap petSwap;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (petSwap.lizardActive == false)
        {
            transform.position = lizardStorage.transform.position;
        }

        if (petSwap.lizardActive == true)
        {
            transform.position = player.transform.position;
        }
    }
}
