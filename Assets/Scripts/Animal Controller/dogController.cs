using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogController : MonoBehaviour
{
    public NewPetSwap petSwap;
    public GameObject dogStorage;
    public GameObject player;
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

        if (petSwap.dogActive == false)
        {
            transform.position = dogStorage.transform.position;
        }

        if (petSwap.dogActive == true)
        {
            transform.position = player.transform.position;
        }
    }
}
