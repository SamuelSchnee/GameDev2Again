using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewPetSwap : MonoBehaviour
{
    static NewPetSwap instance;
    public TeleporterScript tele;
    public PlatformController platCnt;
    public CameraController cameraCnt;
    public HUDController HUD;

    private Rigidbody2D playerRB;
    private BoxCollider2D playerBC;
    private Transform playerTFM;
    private AudioSource GameAudio;

    public AudioClip platformLand;
    public AudioClip jumpLand;
    public AudioClip doorOpen;
    public AudioClip walking;


    public GameObject waterWall1;
    public GameObject waterWall2;
    public GameObject EKey;

    public GameObject fakeTurtle;
    public GameObject fakeHamster;
    public GameObject fakeLizard;
    public GameObject fakeBird;

    // Gameobjects for the hamster's ability
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
    public GameObject rope6;
    public GameObject rope62;

    //checks for what animal is being used
    public bool dogActive = true;
    public bool lizardActive = false;
    public bool birdActive = false;
    public bool turtleActive = false;
    public bool hamsterActive = false;
    public bool canSwitch;
    public bool waiting;
    public bool cutScene = false;

    //checks for what animals have been unlocked
    public bool lizardUnlock = false;
    public bool birdUnlock = false;
    public bool turtleUnlock = false;
    public bool hamsterUnlock = false;

    //checks for climbing, swimming, or getting close to a wall
    public bool climbingWall = false;
    public bool inWater;
    public bool cameraMoving = false;

    //floats having to do with movement
    public float horizontalInput;
    public float verticalInput;
    public float speed;
    public float jumpStrength;
    public float delayCounter;

    public int jumpCount;

    // Start is called before the first frame update
    void Start()
    {
        jumpStrength = 400;
        playerRB = GetComponent<Rigidbody2D>();
        canSwitch = true;
        playerBC = GetComponent<BoxCollider2D>();
        GameAudio = GetComponent<AudioSource>();
    }
    void Update()
    {
        //Allowed for pauses in game. 
        //Would fix by using invoke
        if (waiting == true)
        {
            delayCounter += 1;
        }

        //allow the character to climb walls by turning off gravity
        if (climbingWall == true)
        {
            Debug.Log("hitting wall");
            playerRB.gravityScale = 0;

            verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector2.up * verticalInput * Time.deltaTime * speed);
        }

        //resets gravity
        if (climbingWall == false)
        {
            playerRB.gravityScale = 2;
        }

        //allows player to jump if the situation permits
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0 && lizardActive == false && turtleActive == false && cutScene == false)
        {
            playerRB.AddForce(Vector2.up * jumpStrength * Time.deltaTime, ForceMode2D.Impulse);
            jumpCount -= 1;

        }

        // calls the proper parts of the script depending on what animal is being used
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

        //allows the player to move outside of cutscenes
        if (cutScene == false)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector2.right * horizontalInput * Time.deltaTime * speed);
        }

        //allows the player to switch between each animal by using number keys
        if (Input.GetKeyDown(KeyCode.Alpha1) && dogActive == false && canSwitch == true && cutScene == false)
        {
            dogActive = true;

            lizardActive = false;
            birdActive = false;
            turtleActive = false;
            hamsterActive = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && lizardActive == false && lizardUnlock == true && canSwitch == true && cutScene == false)
        {
            lizardActive = true;

            dogActive = false;
            birdActive = false;
            turtleActive = false;
            hamsterActive = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && hamsterActive == false && hamsterUnlock == true && canSwitch == true && cutScene == false)
        {
            hamsterActive = true;

            dogActive = false;
            birdActive = false;
            turtleActive = false;
            lizardActive = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && turtleActive == false && turtleUnlock == true && canSwitch == true && cutScene == false)
        {
            turtleActive = true;

            dogActive = false;
            lizardActive = false;
            hamsterActive = false;
            birdActive = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha5) && birdActive == false && birdUnlock == true && canSwitch == true && cutScene == false)
        {
            birdActive = true;

            dogActive = false;
            lizardActive = false;
            hamsterActive = false;
            turtleActive = false;
        }
            
        //activates/deactivates barriers that only the turtle can pass
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
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        //allows the player to unlock characters after interacting with their cages
        if (other.gameObject.tag == "lizardUnlock" && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("entered");
            lizardUnlock = true;
        }

        if (other.gameObject.tag == "birdUnlock" && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("bird unlocked");
            birdUnlock = true;
            waiting = true;
        }

        if (other.gameObject.tag == "turtleUnlock" && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("turtle unlocked");
            turtleUnlock = true;
        }

        if (other.gameObject.tag == "hamsterUnlock" && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("hamster unlocked");
            hamsterUnlock = true;
        }

        //detects if a player is able to climb a wall
        if (other.gameObject.tag == "wall" && lizardActive == true)
        {
            climbingWall = true;
        }
        
        //detects if a player is able to swim
        if (other.gameObject.tag == "water")
        {
            inWater = true;
        }

        //detects if the character is standing by a rope and allows them to cut it.
        //this could be fixed in mutliple ways
        //it could be simplified by using arrays
        //insteading of using Coroutines, I should have used Invoke
        if (other.gameObject.tag == "rope1")
        {
            Debug.Log("at rope 1");
        }
        if (other.gameObject.tag == "rope1" && Input.GetKeyDown(KeyCode.E) && hamsterActive == true)
        {
            Debug.Log("cutting Rope1");
            StartCoroutine(Rope1Cut());
        }
        if (other.gameObject.tag == "rope2" && Input.GetKeyDown(KeyCode.E) && hamsterActive == true)
        {
            StartCoroutine(Rope2Cut());
        }
        if (other.gameObject.tag == "rope3" && Input.GetKeyDown(KeyCode.E) && hamsterActive == true)
        {
            StartCoroutine(Rope3Cut());
        }
        if (other.gameObject.tag == "rope4" && Input.GetKeyDown(KeyCode.E) && hamsterActive == true)
        {
            StartCoroutine(Rope4Cut());
        }
        if (other.gameObject.tag == "rope5" && Input.GetKeyDown(KeyCode.E) && hamsterActive == true)
        {
            StartCoroutine(Rope5Cut());
        }
        if (other.gameObject.tag == "rope6" && Input.GetKeyDown(KeyCode.E) && hamsterActive == true)
        {
            StartCoroutine(Rope6Cut());
        }

        //controls the doors
        //again this could be cleaned up with arrays
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (other.gameObject.tag == "H1In" && dogActive == true)
            {
                GameAudio.PlayOneShot(doorOpen, .2f);
                tele.house1I = true;
            }
            if (other.gameObject.tag =="H1DI" && dogActive == true)
            {
                GameAudio.PlayOneShot(doorOpen, .2f);
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
            if (other.gameObject.tag == "H2I" && dogActive == true)
            {
                GameAudio.PlayOneShot(doorOpen, .2f);
                tele.house2I = true;
            }
            if (other.gameObject.tag == "H2O")
            {
                tele.house2O = true;
            }
            if (other.gameObject.tag == "H3I" && dogActive == true)
            {
                GameAudio.PlayOneShot(doorOpen, .2f);
                tele.house3I = true;
            }
            if (other.gameObject.tag == "H3O")
            {
                tele.house3O = true;
            }
            if (other.gameObject.tag == "H4I" && dogActive == true)
            {
                GameAudio.PlayOneShot(doorOpen, .2f);
                tele.house4I = true;
            }
            if (other.gameObject.tag == "H4O")
            {
                tele.house4O = true;
            }
            if (other.gameObject.tag == "finalDoor")
            {
                tele.finalDoor = true;
            }
            if (other.gameObject.tag == "StartDoorIn" && dogActive == true)
            {
                GameAudio.PlayOneShot(doorOpen, .2f);
                tele.startDoorIn = true;
            }
            if (other.gameObject.tag == "startDoorOut" && dogActive == true)
            {
                GameAudio.PlayOneShot(doorOpen, .2f);
                tele.startDoorOut = true;
            }
        }

        //controlls the doors that only the hamster can enter
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

        //activates reminder that the character can't go into water withought the turtle
        if (other.gameObject.tag == "waterWall")
        {
            Debug.Log("hitting water wall");
            HUD.waterWall = true;
        }
    }

    //a pause for camera cutscenes
    IEnumerator cameraWait()
    {
        yield return new WaitForSecondsRealtime(2);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //resets gravity to normal after exiting the water or jumping off a wall
        if (collision.gameObject.tag == "wall")
        {
            climbingWall = false;
            jumpCount = 1;
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
        //resets jump
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

    // Changes hitbox size, ground speed, jump height, and jump count depending on character
    private void playAsDog()
    {
        transform.localScale = new Vector2(4.089289f, 2.757078f);
        playerBC.offset = new Vector2(0, 0.12f);
        speed = 20;
        jumpStrength = 250;

        if (jumpCount < 1)
        {
            speed = 10;
        }
    }

    private void playAsLizard()
    {
        speed = 5;
        // makes it so that the character can't jump
        jumpStrength = 0;
        transform.localScale = new Vector2(1.75f, 0.75f);
        playerBC.offset = new Vector2(0.07f, -0.05f);
    }

    private void playAsHamster()
    {
        speed = 10;
        transform.localScale = new Vector2(1.04f, 0.4424591f);
        playerBC.offset = new Vector2(0, -.05f);
        jumpStrength = 250;
    }

    private void playAsTurtle()
    {
        speed = 2;
        transform.localScale = new Vector2(1.38f, 0.6f);
        playerBC.offset = new Vector2(-0.01f, 0.1f);

        if (inWater == true)
        {
            verticalInput = Input.GetAxis("Vertical");
            speed = 15;
            playerRB.gravityScale = 0;
            transform.Translate(Vector2.up * verticalInput * Time.deltaTime * speed);
        }
    }

    private void playAsBird()
    {
        speed = 4;
        transform.localScale = new Vector2(1.88f, 1.05f);
        playerBC.offset = new Vector2(0, 0.09f);
        playerBC.size = new Vector2(1, 1.06f);

        //changes air speed, fall speed, and jump strength depending on how many jumps you have left 
        if (jumpCount < 2)
        {
            speed = 15;
        }

        //allows the character to glide slightly after using all jumps
        if (jumpCount == 0)
        {
            playerRB.gravityScale = 1.75f;
        }

        if (jumpCount == 0 || jumpCount == 2)
        {
            jumpStrength = 250;
        }

        if (jumpCount == 1)
        {
            jumpStrength = 300;
        }

        //allows the player to cancel out the glide mechanic
        if (Input.GetKeyDown(KeyCode.S) && jumpCount == 0)
        {
            playerRB.gravityScale = 2;
        }
    }

    //fixes a problem where the E indicator was staying active after cutting a rope
    //I should have used Invoke and arrays to clean this up
    IEnumerator Rope1Cut(){
        platCnt.plat1Grav = true;
        Destroy(rope1);
        Destroy(rope12);
        yield return new WaitForSeconds(.25f);
        GameAudio.PlayOneShot(platformLand, .5f);
        yield return new WaitForSeconds(.2f);
        EKey.SetActive(false);
    }
    IEnumerator Rope2Cut(){
        platCnt.plat2Grav = true;
        Destroy(rope2);
        Destroy(rope22);
        yield return new WaitForSeconds(.25f);
        GameAudio.PlayOneShot(platformLand, .5f);
        yield return new WaitForSeconds(.25f);
        EKey.SetActive(false);
    }
    IEnumerator Rope3Cut(){
        platCnt.plat3Grav = true;
        Destroy(rope3);
        Destroy(rope32);
        yield return new WaitForSeconds(.25f);
        GameAudio.PlayOneShot(platformLand, .5f);
        yield return new WaitForSeconds(.25f);
        EKey.SetActive(false);
    }
    IEnumerator Rope4Cut(){
        platCnt.plat4Grav = true;
        Destroy(rope4);
        Destroy(rope42);
        yield return new WaitForSeconds(.25f);
        GameAudio.PlayOneShot(platformLand, .5f);
        yield return new WaitForSeconds(.25f);
        EKey.SetActive(false);
    }
    IEnumerator Rope5Cut(){
        platCnt.birdGrav = true;
        Destroy(rope5);
        Destroy(rope52);
        yield return new WaitForSeconds(.25f);
        EKey.SetActive(false);
    }
    IEnumerator Rope6Cut(){
        platCnt.plat5Grav = true;
        Destroy(rope6);
        Destroy(rope62);
        yield return new WaitForSeconds(.25f);
        GameAudio.PlayOneShot(platformLand, .5f);
        yield return new WaitForSeconds(.25f);
        EKey.SetActive(false);
    }
}
