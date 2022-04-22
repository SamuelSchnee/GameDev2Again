using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public CameraController cameracontroller;
    public NewPetSwap petSwap;
    public TeleporterScript tele;
    public GameObject gameCamera;

    public GameObject narration1;
    public GameObject narration2;
    public GameObject narrationbox;
    public GameObject spacebar2;

    public GameObject cutscene1;
    public GameObject cutscene2;

    public GameObject finalText1;
    public GameObject finalText2;

    public int cutsceneCount;
    public int finalTextCount;

    // Start is called before the first frame update
    void Start()
    {
        cameracontroller.cameraCutscene = true;
        cutsceneCount = 0;
        finalTextCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(cameracontroller.cameraCutscene == true)
        {
            StartCoroutine(cutscene());
        }

        if(tele.finalText == true)
        {
            StartCoroutine(finalText());
        }
    }

    IEnumerator cutscene()
    {
        if (cutsceneCount == 0)
        {
            petSwap.cutScene = true;
            narration1.SetActive(true);
            narrationbox.SetActive(true);
            spacebar2.SetActive(true);
            Debug.Log("getting there");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("working");
                cutsceneCount = 1;
            }
        }
        if (cutsceneCount == 1)
        {
            petSwap.cutScene = true;
            narration1.SetActive(false);
            narration2.SetActive(true);
            yield return new WaitForSeconds(.2f);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                narration2.SetActive(false);
                narrationbox.SetActive(false);
                spacebar2.SetActive(false);
                petSwap.cutScene = false;
                cameracontroller.cameraCutscene = false;
                cutsceneCount = 2;
            }
        }       
    }
    IEnumerator finalText()
    {
        if(finalTextCount == 0)
        {
            cameracontroller.blackScreen.SetActive(true);
            petSwap.cutScene = true;
            narrationbox.SetActive(true);
            finalText1.SetActive(true);
            spacebar2.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                finalTextCount = 1;
            }
        }
        if(finalTextCount == 1)
        {
            finalText1.SetActive(false);
            finalText2.SetActive(true);
            yield return new WaitForSeconds(.2f);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                tele.finished = true;
            }
        }
    }
}
