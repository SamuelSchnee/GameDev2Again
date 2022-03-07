using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleporterScript : MonoBehaviour
{
    public NewPetSwap petSwap;
    public TextController text;

    public bool house1I = false;
    public bool house1O = false;
    public bool house1DI = false;
    public bool house1DO = false;
    public bool house2I = false;
    public bool hamsterI1 = false;
    public bool hamsterO1 = false;
    public bool hamsterI2 = false;
    public bool hamsterO2 = false;
    public bool house2O = false;
    public bool house3I = false;
    public bool house3O = false;
    public bool house4I = false;
    public bool house4O = false;
    public bool houseBreak = false;
    public bool finalDoor = false;
    public bool startDoorIn = false;
    public bool startDoorOut = false;

    public GameObject player;
    public GameObject HouseIn1;
    public GameObject HouseOut1;
    public GameObject HouseDI1;
    public GameObject HouseDO1;
    public GameObject HouseIn2;
    public GameObject HamsterIn1;
    public GameObject HamsterOut1;
    public GameObject HamsterIn2;
    public GameObject HamsterOut2;
    public GameObject HouseOut2;
    public GameObject HouseIn3;
    public GameObject HouseOut3;
    public GameObject HouseIn4;
    public GameObject HouseOut4;
    public GameObject brokenHouse;
    public GameObject SDI;
    public GameObject SDO;

    public GameObject lizardhelptext;
    public GameObject turtlehelptext;
    public GameObject textBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (house1I == true)
        {
            Debug.Log("xyz");
            player.transform.position = HouseIn1.transform.position;
            house1I = false;
        }
        if (house1DI == true)
        {
            Debug.Log("teleporting");
            player.transform.position = HouseDI1.transform.position;
            house1DI = false;
        }
        if (house1DO == true)
        {
            player.transform.position = HouseDO1.transform.position;
            house1DO = false;
        }
        if (house1O == true)
        {
            player.transform.position = HouseOut1.transform.position;
            house1O = false;
        }
        if (house2I == true)
        {
            player.transform.position = HouseIn2.transform.position;
            if (petSwap.hamsterUnlock == false)
            {
                StartCoroutine(LizardHelp());
            }
            house2I = false;
        }
        if (house2O == true)
        {
            player.transform.position = HouseOut2.transform.position;
            house2O = false;
        }
        if (house3I == true)
        {
            player.transform.position = HouseIn3.transform.position;
            if (petSwap.lizardUnlock == false)
            {
                StartCoroutine(turtleHelp());
            }
            house3I = false;
        }
        if (house3O == true)
        {
            player.transform.position = HouseOut3.transform.position;
            house3O = false;
        }
        if (house4I == true)
        {
            player.transform.position = HouseIn4.transform.position;
            house4I = false;
        }
        if (house4O == true)
        {
            player.transform.position = HouseOut4.transform.position;
            house4O = false;
        }

        if (hamsterI1 == true)
        {
            player.transform.position = HamsterIn1.transform.position;
            petSwap.canSwitch = false;
            hamsterI1 = false;
        }
        if (hamsterI2 == true)
        {
            player.transform.position = HamsterIn2.transform.position;
            petSwap.canSwitch = false;
            hamsterI2 = false;
        }
        if (hamsterO1 == true)
        {
            player.transform.position = HamsterOut1.transform.position;
            petSwap.canSwitch = true;
            hamsterO1 = false;
        }
        if (hamsterO2 == true)
        {
            player.transform.position = HamsterOut2.transform.position;
            petSwap.canSwitch = true;
            hamsterO2 = false;
        }

        if (houseBreak == true)
        {
            player.transform.position = brokenHouse.transform.position;
            petSwap.jumpCount = 1;
            houseBreak = false;
        }
        if (finalDoor == true)
        {
            SceneManager.LoadScene("WinScene");
        }
        if (startDoorOut == true)
        {
            player.transform.position = SDO.transform.position;
            startDoorOut = false;
        }
        if (startDoorIn == true)
        {
            player.transform.position = SDI.transform.position;
            startDoorIn = false;
        }
    }

    IEnumerator LizardHelp(){
         yield return new WaitForSeconds(.5f);
         lizardhelptext.SetActive(true);
         textBox.SetActive(true);
         yield return new WaitForSeconds(4);
         lizardhelptext.SetActive(false);
         textBox.SetActive(false);
    }
    IEnumerator turtleHelp(){
        yield return new WaitForSeconds(.5f);
        turtlehelptext.SetActive(true);
        textBox.SetActive(true);
        yield return new WaitForSeconds(4);
        turtlehelptext.SetActive(false);
        textBox.SetActive(false);
    }
}
