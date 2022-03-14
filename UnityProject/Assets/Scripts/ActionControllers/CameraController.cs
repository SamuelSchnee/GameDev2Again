using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public bool loadingStageBreak = false;
    public TeleporterScript tele;
    public NewPetSwap petswap;
    public CutsceneController cutscene;

    public float loadTime;

    public GameObject blackScreen;

    public bool followingPlayer = true;
    public bool cameraCutscene;

    public GameObject cutscene1;
    public GameObject cutscene2;

    // Start is called before the first frame update
    void Start()
    {
        followingPlayer = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraCutscene == true && cutscene.cutsceneCount == 0)
        {
            transform.position = new Vector3(cutscene1.transform.position.x, cutscene1.transform.position.y, -60);
        }
        if (cameraCutscene == true && cutscene.cutsceneCount == 1)
        {
            transform.position = new Vector3(cutscene2.transform.position.x, cutscene2.transform.position.y, -60);
        }
        if (followingPlayer == true && cameraCutscene == false)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2, -60);
        }
        if (followingPlayer == false && cameraCutscene == false)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y + 2, -60);
        }

        if (loadingStageBreak == false)
        {
            blackScreen.SetActive(false);
        }

        if (loadingStageBreak == true)
        {
            /*blackScreen.SetActive(true);
            loadTime += 1;
            tele.houseBreak = true;*/
            StartCoroutine(houseBreakCutscene());
        }

        if (loadTime >= 500)
        {
            loadingStageBreak = false;
            
        }
        if(tele.finalText == true)
        {
            blackScreen.SetActive(true);
        }
    }
    IEnumerator houseBreakCutscene()
    {
        blackScreen.SetActive(true);
        petswap.cutScene = true;
        tele.houseBreak = true;
        yield return new WaitForSecondsRealtime(1.5f);
        loadingStageBreak = false;
        petswap.cutScene = false;

    }
}
