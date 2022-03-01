using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public bool loadingStageBreak = false;
    public TeleporterScript tele;
    public NewPetSwap petswap;

    public float loadTime;

    public GameObject blackScreen;

    public bool followingPlayer = true;

    // Start is called before the first frame update
    void Start()
    {
        followingPlayer = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (followingPlayer == true)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2, -60);
        }
        if (followingPlayer == false)
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
