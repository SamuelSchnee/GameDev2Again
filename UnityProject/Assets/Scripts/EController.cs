using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EController : MonoBehaviour
{
    public GameObject EKey;
    public NewPetSwap petSwap;
    

    // Start is called before the first frame update
    void Start()
    {
        EKey.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "H1In" || other.gameObject.tag == "H1DI" || other.gameObject.tag == "H1DO" || other.gameObject.tag == "H1O")
        {
            if(petSwap.dogActive == true)
            {
                EKey.SetActive(true);
            }

            if(petSwap.dogActive == false)
            {
                EKey.SetActive(false);
            }
        }
        if (other.gameObject.tag == "hamsterUnlock" && petSwap.hamsterUnlock == false || other.gameObject.tag == "lizardUnlock" && petSwap.lizardUnlock == false|| other.gameObject.tag == "turtleUnlock" && petSwap.turtleUnlock == false || other.gameObject.tag == "birdUnlock" && petSwap.birdUnlock == false)
        {
            EKey.SetActive(true);
        }
        if (other.gameObject.tag == "H2I" || other.gameObject.tag == "H2O" || other.gameObject.tag == "H3I" || other.gameObject.tag == "H3O" || gameObject.tag == "H4I" || gameObject.tag == "H4O" || other.gameObject.tag == "startDoorOut" || other.gameObject.tag == "StartDoorIn")
        {
            if (petSwap.dogActive == true)
            {
                EKey.SetActive(true);
            }
            if (petSwap.dogActive == false)
            {
                EKey.SetActive(false);
            }
        }

        if (other.gameObject.tag == "hamsterDoorIn1" || other.gameObject.tag == "hamsterDoorOut2" || other.gameObject.tag == "hamsterDoorIn2" || other.gameObject.tag == "hamsterDoorOut1")
        {
            if (petSwap.hamsterActive == true)
            {
                EKey.SetActive(true);
            }
            if (petSwap.hamsterActive == false)
            {
                EKey.SetActive(false);
            }
        }

        if (other.gameObject.tag == "rope1" || other.gameObject.tag == "rope2" || other.gameObject.tag == "rope3" || other.gameObject.tag == "rope4" || other.gameObject.tag == "rope5" || other.gameObject.tag == "rope6")
        {
            if (petSwap.hamsterActive == true)
            {
                EKey.SetActive(true);
            }
            if (petSwap.hamsterActive == false)
            {
                EKey.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "H1In" || other.gameObject.tag == "H1DI" || other.gameObject.tag == "H1DO" || other.gameObject.tag == "H1O")
        {
            EKey.SetActive(false);
        }
        if (other.gameObject.tag == "hamsterUnlock" || other.gameObject.tag == "lizardUnlock" || other.gameObject.tag == "turtleUnlock" || other.gameObject.tag == "birdUnlock")
        {
            EKey.SetActive(false);
        }
        if (other.gameObject.tag == "H2I" || other.gameObject.tag == "H2O" || other.gameObject.tag == "H3I" || other.gameObject.tag == "H3O" || gameObject.tag == "H4I" || gameObject.tag == "H4O" || other.gameObject.tag == "startDoorOut" || other.gameObject.tag == "StartDoorIn")
        {
            EKey.SetActive(false);
        }

        if (other.gameObject.tag == "hamsterDoorIn1" || other.gameObject.tag == "hamsterDoorOut2" || other.gameObject.tag == "hamsterDoorIn2" || other.gameObject.tag == "hamsterDoorOut1")
        {
            EKey.SetActive(false);
        }

        if (other.gameObject.tag == "rope1" || other.gameObject.tag == "rope2" || other.gameObject.tag == "rope3" || other.gameObject.tag == "rope4" || other.gameObject.tag == "rope5" || other.gameObject.tag == "rope6")
        {
            EKey.SetActive(false);
        }
    }
}
