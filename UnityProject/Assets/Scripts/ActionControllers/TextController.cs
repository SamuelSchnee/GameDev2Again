using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour
{
    public NewPetSwap petSwap;
    public HUDController Hud;

    private bool hamsterUnlocked;
    private bool lizardUnlocked;
    private bool TurtleUnlocked;
    private bool BirdUnlocked;

    public bool unlock1;
    public bool unlock2;
    public bool unlock3;
    public bool unlock4;

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

    public GameObject LText1;
    public GameObject LText2;
    public GameObject LText3;

    public GameObject TTExt1;
    public GameObject TText2;
    public GameObject TText3;

    public GameObject BText1;
    public GameObject BText2;
    public GameObject BText3;
    public GameObject Btext4;
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
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if( unlock1 == true)
        {
            petSwap.cutScene = true;

            if (hamTextCnt == 1){
                HText1.SetActive(true);
                if(Input.GetKeyDown(KeyCode.Space)){
                    hamTextCnt += 1;
                }
            }
            if (hamTextCnt == 2){
                HText1.SetActive(false);
                HText2.SetActive(true);
                if(Input.GetKeyDown(KeyCode.Space)){
                    hamTextCnt += 1;
                }
            }
            if (hamTextCnt == 3){
                HText2.SetActive(false);
                HText3.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Space)){
                    HText3.SetActive(false);
                    Destroy(fakeHam);
                    petSwap.cutScene = false;
                    hamTextCnt = -1;
                    unlock1 = false;
                }
            }
        }
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
            if (lizTextCnt == 3){
                LText2.SetActive(false);
                LText3.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Space)){
                    LText3.SetActive(false);
                    Destroy(fakeLiz);
                    petSwap.cutScene = false;
                    lizTextCnt = -1;
                    unlock2 = false;
                }
            }
            
        }
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
            if (TurtTextCnt == 3){
                TText2.SetActive(false);
                TText3.SetActive(true);
                if(Input.GetKeyDown(KeyCode.Space)){
                    TText3.SetActive(false);
                    Destroy(fakeTur);
                    petSwap.cutScene = false;
                    TurtTextCnt = -1;
                    unlock3 = false;
                }
            }
        }
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
            if (BirdTextCnt == 4){
                BText3.SetActive(false);
                Btext4.SetActive(true);
                if(Input.GetKeyDown(KeyCode.Space)){
                    Btext4.SetActive(false);
                    Destroy(fakeBird);
                    petSwap.cutScene = false;
                    BirdTextCnt = -1;
                    unlock4 = false;
                }
            }
        }
    }
}
