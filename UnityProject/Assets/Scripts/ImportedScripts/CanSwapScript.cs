using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanSwapScript : MonoBehaviour
{
    public NewPetSwap petSwap;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "noSwap")
        {
            petSwap.canSwitch = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "noSwap")
        {
            petSwap.canSwitch = false;
        }
    }
}
