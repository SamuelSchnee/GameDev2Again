using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterController : MonoBehaviour
{
    public GameObject hamsterStorage;
    public GameObject player;
    public NewPetSwap petSwap;
    public PlatformController platCnt;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (petSwap.hamsterActive == false)
        {
            transform.position = hamsterStorage.transform.position;
        }

        if (petSwap.hamsterActive == true)
        {
            transform.position = player.transform.position;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {

    }
}
