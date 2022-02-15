using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    public NewPetSwap petSwap;

    public TextMeshProUGUI animalUnlockText;
    public TextMeshProUGUI animalAbilityText;

    public bool unlockingHamster = false;
    public bool unlockingLizard = false;
    public bool unlockingTurtle = false;
    public bool unlockingBird = false;
    public bool waterWall = false;

    public float delayCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (delayCounter >= 300)
        {
            animalUnlockText.text = "";
            waterWall = false;
            unlockingHamster = false;
            unlockingBird = false;
            unlockingTurtle = false;
            unlockingLizard = false;
            delayCounter = 0;
        }
        if (unlockingHamster == true)
        {
            animalUnlockText.text = "Hamster Unlocked!";
            delayCounter += 1;
        }
        if (unlockingLizard == true)
        {
            animalUnlockText.text = "Lizard Unlocked!";
            delayCounter += 1;
        }
        if (unlockingTurtle == true)
        {
            animalUnlockText.text = "Turtle Unlocked!";
            delayCounter += 1;
        }
        if (unlockingBird == true)
        {
            animalUnlockText.text = "Bird Unlocked!";
            delayCounter += 1;
        }
        if (waterWall == true)
        {
            animalUnlockText.text = "Only the turtle can swim";
            delayCounter += 1;
        }

        if (petSwap.dogActive == true)
        {
            animalAbilityText.text = "Go through large doors with E";
        }
        if (petSwap.hamsterActive == true)
        {
            animalAbilityText.text = "Go through small holes and cut ropes with E ";
        }
        if (petSwap.lizardActive == true)
        {
            animalAbilityText.text = "Climb walls with W & S";
        }
        if (petSwap.turtleActive == true)
        {
            animalAbilityText.text = "Swim through the water using W, A, S, & D";
        }
        if (petSwap.birdActive == true)
        {
            animalAbilityText.text = "Double Jump by pressing SPACE in the air";
        }
    }
}
