using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalHudController : MonoBehaviour
{
    public NewPetSwap petSwap;
    public TeleporterScript tele;

    public GameObject dogHUD;
    public GameObject hamHUD;
    public GameObject lizHUD;
    public GameObject turtHUD;
    public GameObject birdHUD;

    private Image dogColor;
    private Image hamColor;
    private Image lizColor;
    private Image turtColor;
    private Image birdColor;

    // Start is called before the first frame update
    void Start()
    {
        dogColor = dogHUD.GetComponent<Image>();
        hamColor = hamHUD.GetComponent<Image>();
        lizColor = lizHUD.GetComponent<Image>();
        turtColor = turtHUD.GetComponent<Image>();
        birdColor = birdHUD.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(petSwap.hamsterUnlock == true)
        {
            hamHUD.SetActive(true);
        }
        if(petSwap.lizardUnlock == true)
        {
            lizHUD.SetActive(true);
        }
        if(petSwap.turtleUnlock == true)
        {
            turtHUD.SetActive(true);
        }
        if(petSwap.birdUnlock == true)
        {
            birdHUD.SetActive(true);
        }

        if(petSwap.dogActive == true)
        {
            dogColor.color = new Color(1, 1, 1);
            hamColor.color = new Color(.5f, .5f, .5f);
            lizColor.color = new Color(.5f, .5f, .5f);
            turtColor.color = new Color(.5f, .5f, .5f);
            birdColor.color = new Color(.5f, .5f, .5f);
        }
        if(petSwap.hamsterActive == true)
        {
            dogColor.color = new Color(.5f, .5f, .5f);
            hamColor.color = new Color(1, 1, 1);
            lizColor.color = new Color(.5f, .5f, .5f);
            turtColor.color = new Color(.5f, .5f, .5f);
            birdColor.color = new Color(.5f, .5f, .5f);
        }
        if(petSwap.lizardActive == true)
        {
            dogColor.color = new Color(.5f, .5f, .5f);
            hamColor.color = new Color(.5f, .5f, .5f);
            lizColor.color = new Color(1, 1, 1);
            turtColor.color = new Color(.5f, .5f, .5f);
            birdColor.color = new Color(.5f, .5f, .5f);
        }
        if(petSwap.turtleActive == true)
        {
            dogColor.color = new Color(.5f, .5f, .5f);
            hamColor.color = new Color(.5f, .5f, .5f);
            lizColor.color = new Color(.5f, .5f, .5f);
            turtColor.color = new Color(1, 1, 1);
            birdColor.color = new Color(.5f, .5f, .5f);
        }
        if(petSwap.birdActive == true)
        {
            dogColor.color = new Color(.5f, .5f, .5f);
            hamColor.color = new Color(.5f, .5f, .5f);
            lizColor.color = new Color(.5f, .5f, .5f);
            turtColor.color = new Color(.5f, .5f, .5f);
            birdColor.color = new Color(1, 1, 1);
        }

        if(tele.finalText == true)
        {
            dogHUD.SetActive(false);
            hamHUD.SetActive(false);
            lizHUD.SetActive(false);
            turtHUD.SetActive(false);
            birdHUD.SetActive(false);
        }
    }
}
