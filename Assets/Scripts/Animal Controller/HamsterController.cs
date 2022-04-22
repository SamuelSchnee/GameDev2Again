using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterController : MonoBehaviour
{
    public GameObject hamsterStorage;
    public GameObject player;
    public NewPetSwap petSwap;
    public PlatformController platCnt;

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

        if (petSwap.hamsterActive == false)
        {
            transform.position = hamsterStorage.transform.position;
        }

        if (petSwap.hamsterActive == true)
        {
            transform.position = player.transform.position;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {

    }
}
