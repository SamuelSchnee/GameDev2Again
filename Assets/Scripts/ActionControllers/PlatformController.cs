using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public bool plat1Grav = false;
    public bool plat2Grav = false;
    public bool plat3Grav = false;
    public bool plat4Grav = false;
    public bool plat5Grav = false;
    public bool birdGrav = false;

    public GameObject plat1;
    public GameObject plat2;
    public GameObject plat3;
    public GameObject plat4;
    public GameObject plat5;
    public GameObject birdCage;

    public Rigidbody2D p1Rb;
    public Rigidbody2D p2Rb;
    public Rigidbody2D p3Rb;
    public Rigidbody2D p4Rb;
    public Rigidbody2D p5Rb;
    public Rigidbody2D BcRb;
    
    // Start is called before the first frame update
    void Start()
    {
        p1Rb = plat1.GetComponent<Rigidbody2D>();
        p2Rb = plat2.GetComponent<Rigidbody2D>();
        p3Rb = plat3.GetComponent<Rigidbody2D>();
        p4Rb = plat4.GetComponent<Rigidbody2D>();
        p5Rb = plat5.GetComponent<Rigidbody2D>();
        BcRb = birdCage.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (plat1Grav == true)
        {
            p1Rb.gravityScale = 2;
        }
        if (plat2Grav == true)
        {
            p2Rb.gravityScale = 2;
        }
        if (plat3Grav == true)
        {
            p3Rb.gravityScale = 2;
        }
        if (plat4Grav == true)
        {
            p4Rb.gravityScale = 2;
        }
        if (plat5Grav == true)
        {
            p5Rb.gravityScale = 2;
        }
        if (birdGrav == true)
        {
            BcRb.gravityScale = 2;
        }
    }
}
