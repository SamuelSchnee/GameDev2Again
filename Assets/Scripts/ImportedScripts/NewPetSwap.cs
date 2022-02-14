using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewPetSwap : MonoBehaviour
{
    static NewPetSwap instance;
    public TeleporterScript tele;
    public PlatformController platCnt;

    private Rigidbody2D playerRB;
    private Transform playerTFM;

    public GameObject waterWall1;
    public GameObject waterWall2;

    public GameObject rope1;
    public GameObject rope12;
    public GameObject rope2;
    public GameObject rope22;
    public GameObject rope3;
    public GameObject rope32;
    public GameObject rope4;
    public GameObject rope42;
    public GameObject rope5;
    public GameObject rope52;

    public bool dogActive = true;
    public bool lizardActive = false;
    public bool birdActive = false;
    public bool turtleActive = false;
    public bool hamsterActive = false;
    private bool canSwitch;

    public bool lizardUnlock = false;
    public bool birdUnlock = false;
    public bool turtleUnlock = false;
    public bool hamsterUnlock = false;

    public bool climbingWall = false;
    public bool inWater;
    public bool cameraMoving = false;

    public float horizontalInput;
    public float verticalInput;
    public float speed;
    public float jumpStrength;

    public int jumpCount;
    public int gemCount;

    // Start is called before the first frame update
    void Start()
    {
        jumpStrength = 400;
        playerRB = GetComponent<Rigidbody2D>();
        canSwitch = true;
    }

    /*private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        //DontDestroyOnLoad(this.gameObject);

        if (climbingWall == true)
        {
            Debug.Log("hitting wall");
            playerRB.gravityScale = 0;

            verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector2.up * verticalInput * Time.deltaTime * speed);
        }

        if (climbingWall == false)
        {
            playerRB.gravityScale = 2;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0 && lizardActive == false && turtleActive == false)
        {
            playerRB.AddForce(Vector2.up * jumpStrength);
            jumpCount -= 1;

        }

        if (dogActive == true)
        {
            playAsDog();
        }

        if (lizardActive == true)
        {
            playAsLizard();
        }

        if (hamsterActive == true)
        {
            playAsHamster();
        }

        if (turtleActive == true)
        {
            playAsTurtle();
        }

        if (birdActive == true)
        {
            playAsBird();
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontalInput * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Alpha1) && dogActive == false && canSwitch == true)
        {
            dogActive = true;

            lizardActive = false;
            birdActive = false;
            turtleActive = false;
            hamsterActive = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && lizardActive == false && lizardUnlock == true && canSwitch == true)
        {
            lizardActive = true;

            dogActive = false;
            birdActive = false;
            turtleActive = false;
            hamsterActive = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && hamsterActive == false && hamsterUnlock == true && canSwitch == true)
        {
            hamsterActive = true;

            dogActive = false;
            birdActive = false;
            turtleActive = false;
            lizardActive = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && turtleActive == false && turtleUnlock == true && canSwitch == true)
        {
            turtleActive = true;

            dogActive = false;
            lizardActive = false;
            hamsterActive = false;
            birdActive = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha5) && birdActive == false && birdUnlock == true && canSwitch == true)
        {
            birdActive = true;

            dogActive = false;
            lizardActive = false;
            hamsterActive = false;
            turtleActive = false;
        }

        if (turtleActive == true)
        {
            waterWall1.SetActive(false);
            waterWall2.SetActive(false);
        }
        else if (turtleActive == false)
        {
            waterWall1.SetActive(true);
            waterWall2.SetActive(true);
        }

        if (transform.position.x < 133 && transform.position.x > 94.5)
        {
            canSwitch = false;
        }
        else
        {
            canSwitch = true;
        }

        if (gemCount == 5)
        {
            SceneManager.LoadScene("WinScene");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "lizardUnlock")
        {
            Debug.Log("entered");
            lizardUnlock = true;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "birdUnlock")
        {
            Debug.Log("bird unlocked");
            birdUnlock = true;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "turtleUnlock")
        {
            Debug.Log("turtle unlocked");
            turtleUnlock = true;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "hamsterUnlock")
        {
            Debug.Log("hamster unlocked");
            hamsterUnlock = true;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "gem")
        {
            gemCount += 1;
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "wall" && lizardActive == true)
        {
            climbingWall = true;
        }

        if (other.gameObject.tag == "water")
        {
            inWater = true;
        }

        if (other.gameObject.tag == "rope1")
        {
            Debug.Log("at rope 1");
        }
        if (other.gameObject.tag == "rope1" && Input.GetKeyDown(KeyCode.E) && hamsterActive == true)
        {
            Debug.Log("cutting Rope1");
            platCnt.plat1Grav = true;
            Destroy(rope1);
            Destroy(rope12);
        }
        if (other.gameObject.tag == "rope2" && Input.GetKeyDown(KeyCode.E) && hamsterActive == true)
        {
            platCnt.plat2Grav = true;
            Destroy(rope2);
            Destroy(rope22);
        }
        if (other.gameObject.tag == "rope3" && Input.GetKeyDown(KeyCode.E) && hamsterActive == true)
        {
            platCnt.plat3Grav = true;
            Destroy(rope3);
            Destroy(rope32);
        }
        if (other.gameObject.tag == "rope4" && Input.GetKeyDown(KeyCode.E) && hamsterActive == true)
        {
            platCnt.plat4Grav = true;
            Destroy(rope4);
            Destroy(rope42);
        }
        if (other.gameObject.tag == "rope5" && Input.GetKeyDown(KeyCode.E) && hamsterActive == true)
        {
            platCnt.birdGrav = true;
            Destroy(rope5);
            Destroy(rope52);
        }

        if (Input.GetKeyDown(KeyCode.E) && dogActive == true)
        {
            if (other.gameObject.tag == "H1In")
            {
                tele.house1I = true;
            }
            if (other.gameObject.tag =="H1DI")
            {
                tele.house1DI = true;
            }
            if (other.gameObject.tag == "H1DO")
            {
                tele.house1DO = true;
            }
            if (other.gameObject.tag == "H1O")
            {
                tele.house1O = true;
            }
            if (other.gameObject.tag == "H2I")
            {
                tele.house2I = true;
            }
            if (other.gameObject.tag == "H2O")
            {
                tele.house2O = true;
            }
            if (other.gameObject.tag == "H3I")
            {
                tele.house3I = true;
            }
            if (other.gameObject.tag == "H3O")
            {
                tele.house3O = true;
            }
            if (other.gameObject.tag == "H4I")
            {
                tele.house4I = true;
            }
            if (other.gameObject.tag == "H4O")
            {
                tele.house4O = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && hamsterActive == true)
        {
            if (other.gameObject.tag == "hamsterDoorIn1")
            {
                tele.hamsterI1 = true;
            }
            if (other.gameObject.tag == "hamsterDoorIn2")
            {
                tele.hamsterI2 = true;
            }
            if (other.gameObject.tag == "hamsterDoorOut1")
            {
                tele.hamsterO1 = true;
            }
            if (other.gameObject.tag == "hamsterDoorOut2")
            {
                tele.hamsterO2 = true;
            }
        }
    }

    IEnumerator cameraWait()
    {
        yield return new WaitForSecondsRealtime(2);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            climbingWall = false;
        }

        if (collision.gameObject.tag == "water")
        {
            playerRB.gravityScale = 2;
            speed = 2;
            inWater = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            if (dogActive == true || hamsterActive == true)
            {
                jumpCount = 1;
            }

            if (birdActive == true)
            {
                jumpCount = 2;
            }
        }
    }

    private void playAsDog()
    {
        transform.localScale = new Vector2(2.318059f, 1.39098f);
        speed = 20;
        jumpStrength = 400;

        if (jumpCount < 1)
        {
            speed = 10;
        }
    }

    private void playAsLizard()
    {
        speed = 5;
        jumpStrength = 0;
        transform.localScale = new Vector2(1.3f, 0.73757f);
    }

    private void playAsHamster()
    {
        speed = 10;
        transform.localScale = new Vector2(0.56181f, 0.4424591f);
    }

    private void playAsTurtle()
    {
        speed = 2;
        transform.localScale = new Vector2(1, 0.63759f);

        if (inWater == true)
        {
            verticalInput = Input.GetAxis("Vertical");
            speed = 15;
            playerRB.gravityScale = 0;
            transform.Translate(Vector2.up * verticalInput * Time.deltaTime * speed);
        }

        // if (inWater == false)
        // {
        //     playerRB.gravityScale = 2;
        // }
    }

    private void playAsBird()
    {
        speed = 4;
        transform.localScale = new Vector2(0.575f, 1);

        if (jumpCount < 2)
        {
            speed = 15;
        }

        if (jumpCount == 0)
        {
            playerRB.gravityScale = 1.75f;
        }

        if (jumpCount == 0 || jumpCount == 2)
        {
            jumpStrength = 400;
        }

        if (jumpCount == 1)
        {
            jumpStrength = 500;
        }

        if (Input.GetKeyDown(KeyCode.S) && jumpCount == 0)
        {
            playerRB.gravityScale = 2;
        }
    }
}
