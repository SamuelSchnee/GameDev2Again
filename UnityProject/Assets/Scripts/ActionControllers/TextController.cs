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

        if (hamsterUnlocked = true)
        {
            hamTextCnt = 1;
            unlock1 = true;
            hamsterUnlocked = false;
        }

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
            }
        }
    
    }
}
