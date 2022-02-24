using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public bool loadingStageBreak = false;
    public TeleporterScript tele;

    public float loadTime;

    public GameObject blackScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2, -60);

        if (loadingStageBreak == false)
        {
            blackScreen.transform.position = new Vector2(-50, 50);
        }

        if (loadingStageBreak == true)
        {
            blackScreen.transform.position = new Vector3(transform.position.x, transform.position.y, -50);
            loadTime += 1;
            tele.houseBreak = true;
        }

        if (loadTime >= 500)
        {
            loadingStageBreak = false;
            
        }
    }
}
