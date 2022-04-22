using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardController1 : MonoBehaviour
{
    public GameObject lizardStorage;
    public GameObject player;
    public NewPetSwap petSwap;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = petSwap.horizontalInput;

        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        if (horizontalInput < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
        if (horizontalInput > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (petSwap.lizardActive == false)
        {
            transform.position = lizardStorage.transform.position;
        }

        if (petSwap.lizardActive == true)
        {
            transform.position = player.transform.position;
        }
    }
}
