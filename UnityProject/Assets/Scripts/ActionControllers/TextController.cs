using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour
{
    public NewPetSwap petSwap;
    public HUDController Hud;
    public CameraController cameraCnt;

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

    public GameObject textBox;

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
            StartCoroutine(pauseForHamText());
        }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///Lizard Text
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (unlock2 == true)
        {
            petSwap.cutScene = true;
            StartCoroutine(pauseForLizText());   
        }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///Turtle Text
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (unlock3 == true)
        {
            petSwap.cutScene = true;
            StartCoroutine(pauseForTurtText());
        }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///Bird Text
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (unlock4 == true)
        {
            petSwap.cutScene = true;
            StartCoroutine(pauseForBirdText());
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
            textBox.SetActive(true);
            house2Help.SetActive(true);
            yield return new WaitForSecondsRealtime(2);
            textBox.SetActive(false);
            house2Help.SetActive(false);
        }
        if (House3INVLD == true)
        {
            yield return new WaitForSecondsRealtime(1);
            textBox.SetActive(true);
            house3Help.SetActive(true);
            yield return new WaitForSecondsRealtime(2);
            house3Help.SetActive(false);
            textBox.SetActive(false);
        }

    }
    IEnumerator pauseForHamText()
    {
        if (hamTextCnt == 1)
        {
            textBox.SetActive(true);
            HText1.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                hamTextCnt = 2;
            }
        }
        if (hamTextCnt == 2)
        {
            Debug.Log("hit2");
            HText1.SetActive(false);
            HText2.SetActive(true);
            yield return new WaitForSeconds(.75f);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                hamTextCnt = 3;
            }
        }
        if (hamTextCnt == 3)
        {
            HText2.SetActive(false);
            HText3.SetActive(true);
            yield return new WaitForSeconds(.75f);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                hamTextCnt = 4;
            }
        }
        if (hamTextCnt == 4)
        {
            HText3.SetActive(false);
            HText4.SetActive(true);
            yield return new WaitForSeconds(.75f);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                hamTextCnt = 5;
            }
        }
        if (hamTextCnt == 5)
        {
            HText4.SetActive(false);
            HText5.SetActive(true);
            yield return new WaitForSeconds(.75f);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                hamTextCnt = 6;
            }
        }
        if (hamTextCnt == 6)
        {
            HText5.SetActive(false);
            HText6.SetActive(true);
            yield return new WaitForSeconds(.75f);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                textBox.SetActive(false);
                HText6.SetActive(false);
                Destroy(fakeHam);
                petSwap.cutScene = false;
                Hud.unlockingHamster = true;
                hamTextCnt = -1;
                unlock1 = false;
            }
        }
    }
    /// <summary>
    /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    /// <returns></returns>
    IEnumerator pauseForLizText()
    {
        if (lizTextCnt == 1)
        {
            textBox.SetActive(true);
            LText1.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                lizTextCnt =2;
            }
        }
        if (lizTextCnt == 2)
        {
            LText1.SetActive(false);
            LText2.SetActive(true);
            yield return new WaitForSeconds(.75f);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                lizTextCnt =3;
            }
        }
        if (lizTextCnt == 3)
        {
            LText2.SetActive(false);
            LText3.SetActive(true);
            yield return new WaitForSeconds(.75f);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                lizTextCnt =4;
            }
        }
        if (lizTextCnt == 4)
        {
            LText3.SetActive(false);
            LText4.SetActive(true);
            yield return new WaitForSeconds(.75f);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                lizTextCnt =5;
            }
        }
        if (lizTextCnt == 5)
        {
            LText4.SetActive(false);
            LText5.SetActive(true);
            yield return new WaitForSeconds(.75f);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                lizTextCnt =6;
            }
        }
        if (lizTextCnt == 6)
        {
            LText5.SetActive(false);
            LText6.SetActive(true);
            yield return new WaitForSeconds(.75f);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                textBox.SetActive(false);
                LText6.SetActive(false);
                Destroy(fakeLiz);
                Hud.unlockingLizard = true;
                petSwap.cutScene = false;
                lizTextCnt = -1;
                unlock2 = false;
            }
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///
    IEnumerator pauseForTurtText()
    {
        if (TurtTextCnt == 1)
        {
            textBox.SetActive(true);
            TTExt1.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TurtTextCnt =2;
            }
        }
        if (TurtTextCnt == 2)
        {
            TTExt1.SetActive(false);
            TText2.SetActive(true);
            yield return new WaitForSeconds(.75f);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TurtTextCnt =3;
            }
        }
        if (TurtTextCnt == 3)
        {
            TText2.SetActive(false);
            TText3.SetActive(true);
            yield return new WaitForSeconds(.75f);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TurtTextCnt =4;
            }
        }
        if (TurtTextCnt == 4)
        {
            TText3.SetActive(false);
            TText4.SetActive(true);
            yield return new WaitForSeconds(.75f);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TurtTextCnt =5;
            }
        }
        if (TurtTextCnt == 5)
        {
            TText4.SetActive(false);
            TText5.SetActive(true);
            yield return new WaitForSeconds(.75f);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TurtTextCnt =6;
            }
        }
        if (TurtTextCnt == 6)
        {
            TText5.SetActive(false);
            TText6.SetActive(true);
            yield return new WaitForSeconds(.75f);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                textBox.SetActive(false);
                TText6.SetActive(false);
                Destroy(fakeTur);
                Hud.unlockingTurtle = true;
                petSwap.cutScene = false;
                TurtTextCnt = -1;
                unlock3 = false;
            }
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///
    IEnumerator pauseForBirdText()
    {
        textBox.SetActive(true);
        if (BirdTextCnt == 1)
        {
            BText1.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                BirdTextCnt =2;
            }
        }
        if (BirdTextCnt == 2)
        {
            BText1.SetActive(false);
            BText2.SetActive(true);
            yield return new WaitForSeconds(.75f);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                BirdTextCnt =3;
            }
        }
        if (BirdTextCnt == 3)
        {
            BText2.SetActive(false);
            BText3.SetActive(true);
            yield return new WaitForSeconds(.75f);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                BirdTextCnt =4;
            }
        }
        if (BirdTextCnt == 4)
        {
            BText3.SetActive(false);
            yield return new WaitForSeconds(.75f);
            BText4.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                BirdTextCnt =5;
            }
        }
        if (BirdTextCnt == 5)
        {
            BText4.SetActive(false);
            BText5.SetActive(true);
            yield return new WaitForSeconds(.75f);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                BirdTextCnt =6;
            }
        }
        if (BirdTextCnt == 6)
        {
            BText5.SetActive(false);
            BText6.SetActive(true);
            yield return new WaitForSeconds(.75f);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                BirdTextCnt =7;
            }
        }
        if (BirdTextCnt == 7)
        {
            BText6.SetActive(false);
            BText7.SetActive(true);
            yield return new WaitForSeconds(.75f);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                BirdTextCnt =8;
            }
        }
        if (BirdTextCnt == 8)
        {
            BText7.SetActive(false);
            BText8.SetActive(true);
            yield return new WaitForSeconds(.75f);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                textBox.SetActive(false);
                BText8.SetActive(false);
                Destroy(fakeBird);
                Hud.unlockingBird = true;
                petSwap.cutScene = false;
                BirdTextCnt = -1;
                unlock4 = false;
                yield return new WaitForSeconds(1);
                cameraCnt.loadingStageBreak = true;
            }
        }
    }
}
