using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour
{
    public NewPetSwap petSwap;
    public HUDController Hud;
    public bool wait;

    private bool hamsterUnlocked;
    private bool lizardUnlocked;
    private bool TurtleUnlocked;
    private bool BirdUnlocked;

    public bool unlock1;
    public bool unlock2;
    public bool unlock3;
    public bool unlock4;

    public bool House2INVLD = false;
    public bool House3INVLD = false;
    public bool House4INVLD = false;


    public int hamTextCnt = 0;
    public int lizTextCnt = 0;
    public int TurtTextCnt = 0;
    public int BirdTextCnt = 0;

    public GameObject fakeHam;
    public GameObject fakeLiz;
    public GameObject fakeTur;
    public GameObject fakeBird;

    public GameObject HText1;
    public GameObject HText2;
    public GameObject HText3;
    public GameObject HText4;
    public GameObject HText5;
    public GameObject HText6;

    public GameObject LText1;
    public GameObject LText2;
    public GameObject LText3;
    public GameObject LText4;
    public GameObject LText5;
    public GameObject LText6;

    public GameObject TTExt1;
    public GameObject TText2;
    public GameObject TText3;
    public GameObject TText4;
    public GameObject TText5;
    public GameObject TText6;

    public GameObject BText1;
    public GameObject BText2;
    public GameObject BText3;
    public GameObject BText4;
    public GameObject BText5;
    public GameObject BText6;
    public GameObject BText7;
    public GameObject BText8;

    public GameObject house2Help;
    public GameObject house3Help;
    public GameObject house4Help;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        hamsterUnlocked = petSwap.hamsterUnlock;
        lizardUnlocked = petSwap.lizardUnlock;
        TurtleUnlocked = petSwap.turtleUnlock;
        BirdUnlocked = petSwap.birdUnlock;

        if (hamsterUnlocked == true && hamTextCnt == 0){
            hamTextCnt = 1;
            unlock1 = true;

        }
        if (lizardUnlocked == true && lizTextCnt == 0){
            lizTextCnt = 1;
            unlock2 = true;
        }
        if (TurtleUnlocked == true && TurtTextCnt == 0){
            unlock3 = true;
            TurtTextCnt = 1;
        }
        if (BirdUnlocked == true && BirdTextCnt == 0){
            unlock4 = true;
            BirdTextCnt = 1;
        }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///Hamster Text
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if( unlock1 == true)
        {
            petSwap.cutScene = true;

            if (hamTextCnt == 1){
                HText1.SetActive(true);
                if(Input.GetKeyUp(KeyCode.Space)){
                    hamTextCnt =2;
                }
            }
            if (hamTextCnt == 2){
                Debug.Log("hit2");
                HText1.SetActive(false);
                HText2.SetActive(true);
                wait = true;
                ////////////////Figure this out
                pauseForText();
                if(Input.GetKeyDown(KeyCode.Space) && wait == false){
                    hamTextCnt =3;
                }
            }
            if (hamTextCnt == 3)
            {
                HText2.SetActive(false);
                HText3.SetActive(true);
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    hamTextCnt =4;
                }
            }
            if (hamTextCnt == 4)
            {
                HText3.SetActive(false);
                HText4.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    hamTextCnt =5;
                }
            }
            if (hamTextCnt == 5)
            {
                HText4.SetActive(false);
                HText5.SetActive(true);
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    hamTextCnt =6;
                }
            }
            if (hamTextCnt == 6)
            {
                HText5.SetActive(false);
                HText6.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Space)){
                    HText6.SetActive(false);
                    Destroy(fakeHam);
                    petSwap.cutScene = false;
                    hamTextCnt = -1;
                    unlock1 = false;
                }
            }
        }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///Lizard Text
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (unlock2 == true)
        {
            petSwap.cutScene = true;

            if (lizTextCnt == 1){
                LText1.SetActive(true);
                if(Input.GetKeyDown(KeyCode.Space)){
                lizTextCnt += 1;
                }
            }
            if (lizTextCnt == 2){
                LText1.SetActive(false);
                LText2.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Space)){
                    lizTextCnt += 1;
                }
            }
            if (lizTextCnt == 3)
            {
                LText2.SetActive(false);
                LText3.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    lizTextCnt += 1;
                }
            }
            if (lizTextCnt == 4)
            {
                LText3.SetActive(false);
                LText4.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    lizTextCnt += 1;
                }
            }
            if (lizTextCnt == 5)
            {
                LText4.SetActive(false);
                LText5.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    lizTextCnt += 1;
                }
            }
            if (lizTextCnt == 6){
                LText5.SetActive(false);
                LText6.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Space)){
                    LText6.SetActive(false);
                    Destroy(fakeLiz);
                    petSwap.cutScene = false;
                    lizTextCnt = -1;
                    unlock2 = false;
                }
            }
            
        }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///Turtle Text
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (unlock3 == true)
        {
            petSwap.cutScene = true;

            if (TurtTextCnt == 1){
                TTExt1.SetActive(true);
                if(Input.GetKeyDown(KeyCode.Space)){
                    TurtTextCnt += 1;
                }
            }
            if (TurtTextCnt == 2){
                TTExt1.SetActive(false);
                TText2.SetActive(true);
                if(Input.GetKeyDown(KeyCode.Space)){
                    TurtTextCnt += 1;
                }
            }
            if (TurtTextCnt == 3)
            {
                TText2.SetActive(false);
                TText3.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    TurtTextCnt += 1;
                }
            }
            if (TurtTextCnt == 4)
            {
                TText3.SetActive(false);
                TText4.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    TurtTextCnt += 1;
                }
            }
            if (TurtTextCnt == 5)
            {
                TText4.SetActive(false);
                TText5.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    TurtTextCnt += 1;
                }
            }
            if (TurtTextCnt == 6){
                TText5.SetActive(false);
                TText6.SetActive(true);
                if(Input.GetKeyDown(KeyCode.Space)){
                    TText6.SetActive(false);
                    Destroy(fakeTur);
                    petSwap.cutScene = false;
                    TurtTextCnt = -1;
                    unlock3 = false;
                }
            }
        }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///Bird Text
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (unlock4 == true)
        {
            petSwap.cutScene = true;

            if (BirdTextCnt == 1){
                BText1.SetActive(true);
                if(Input.GetKeyDown(KeyCode.Space)){
                    BirdTextCnt += 1;
                }
            }
            if (BirdTextCnt == 2){
                BText1.SetActive(false);
                BText2.SetActive(true);
                if(Input.GetKeyDown(KeyCode.Space)){
                    BirdTextCnt += 1;
                }
            }
            if (BirdTextCnt == 3){
                BText2.SetActive(false);
                BText3.SetActive(true);
                if(Input.GetKeyDown(KeyCode.Space)){
                    BirdTextCnt += 1;
                }
            }
            if (BirdTextCnt == 4)
            {
                BText3.SetActive(false);
                BText4.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    BirdTextCnt += 1;
                }
            }
            if (BirdTextCnt == 5)
            {
                BText4.SetActive(false);
                BText5.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    BirdTextCnt += 1;
                }
            }
            if (BirdTextCnt == 6)
            {
                BText5.SetActive(false);
                BText6.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    BirdTextCnt += 1;
                }
            }
            if (BirdTextCnt == 7)
            {
                BText6.SetActive(false);
                BText7.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    BirdTextCnt += 1;
                }
            }
            if (BirdTextCnt == 8){
                BText7.SetActive(false);
                BText8.SetActive(true);
                if(Input.GetKeyDown(KeyCode.Space)){
                    BText8.SetActive(false);
                    Destroy(fakeBird);
                    petSwap.cutScene = false;
                    BirdTextCnt = -1;
                    unlock4 = false;
                }
            }
        }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (House2INVLD == true)
        {
            helpText();
        }
        if (House3INVLD == true)
        {
            helpText();
        }
        if (House4INVLD == true)
        {
            helpText();
        }
    }

    IEnumerator helpText()
    {
        if (House2INVLD == true)
        {
            yield return new WaitForSecondsRealtime(1);
            house2Help.SetActive(true);
            yield return new WaitForSecondsRealtime(2);
            house2Help.SetActive(false);
        }
        if (House3INVLD == true)
        {
            yield return new WaitForSecondsRealtime(1);
            house3Help.SetActive(true);
            yield return new WaitForSecondsRealtime(2);
            house3Help.SetActive(false);
        }

    }
    IEnumerator pauseForText()
    {
        yield return new WaitForSecondsRealtime(1);
        wait = false;
    }
}
