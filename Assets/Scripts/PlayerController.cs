using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    public GameObject Key;
    public Vector3 velocity;
    public bool hasKey; 
    public LayerMask solids;
    private SpriteRenderer rend;
    public Animator anim;
    public float speed = 0.2f;

    public GameObject glowstick;

    public Camera MapCamera;
    public Camera MainCamera;
    public GameObject MapLight;

    public GameObject image;
    public GameObject winText;
    public GameObject loseText;
    public GameObject keyNeededText;
    public GameObject glowStickPrompt;
    public TextMeshProUGUI glowStickText;
    
    public GameObject keyPickUp;
    public bool gameOver;
    public GameObject player;

    private int numGlowSticks;
    private bool pushingBox;
    public AudioClip music;
    AudioSource audioSource;
    private bool start;
    private bool level2;
    private bool soundFXOn;
    private bool musicOn;

    private bool canMove;
    void Start()
    {
        soundFXOn = Controller3.sounds;
        musicOn = Controller3.music;
        
        

        canMove = true;
        MainCamera.enabled = true;
        MapCamera.enabled = false;
        MapLight.SetActive(false);
        MapLight.SetActive(false);
        image.SetActive(false);
        pushingBox = false;
        numGlowSticks = 5;
        Scene currentScene = SceneManager.GetActiveScene();
        if(currentScene.name == "Level2")
        {
            level2 = true;
        }

        start = true;
        
        music = Resources.Load<AudioClip>("music");
        
        audioSource = GetComponent<AudioSource>();

        player.transform.localScale = new Vector3(1, 1, 1);
        keyPickUp.SetActive(false);
        gameOver = false;
        
        Key.SetActive(true);

        velocity = new Vector3(0f, 0f, 0f);
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        hasKey = false;

        winText.SetActive(false);
        loseText.SetActive(false);
        keyNeededText.SetActive(false);

        

        
    }

    void Update()
    {
        MainCamera.enabled = true;
        MapCamera.enabled = false;
        MapLight.SetActive(false);
        canMove = true;

        if (start)
        {
            if (musicOn)
            {
                audioSource.Play();
            }
            
            start = false;
        }
        

        if (!gameOver)
        {
            
            anim.speed = 1;

            if (Input.GetKey("m"))
            {
                MapCamera.enabled = true;
                MainCamera.enabled = false;
                MapLight.SetActive(true);
                canMove = false;
                glowStickPrompt.SetActive(false);
            }
            if (Input.GetKey("left") && canMove)
            {
                velocity = new Vector3(-0.07f, 0f, 0f);
                
                anim.Play("WalkLeft");
            }
            else if (Input.GetKey("right") && canMove)
            {
                velocity = new Vector3(0.07f, 0f, 0f);
                
                anim.Play("WalkRight");
            }
            else if (Input.GetKey("down") && canMove)
            {
                velocity = new Vector3(0f, -0.07f, 0f);
                if (pushingBox)
                {
                    velocity = new Vector3(0f, -0.02f, 0f);
                }
                anim.Play("WalkDown");
            }
            else if (Input.GetKey("up") && canMove)
            {
                velocity = new Vector3(0f, 0.07f, 0f);
                
                anim.Play("WalkUp");
            }

            else
            {
                velocity = new Vector3(0f, 0f, 0f);
                anim.speed = 0;
            }
            if (Input.GetKeyDown("x") && numGlowSticks != 0 && level2)
            {
                glowStickPrompt.SetActive(false);
                numGlowSticks--;
                
                glowStickText.text = "Glow Sticks Remaining: " + numGlowSticks;

                Instantiate(glowstick, player.transform.position, Quaternion.identity);
            }
            if (isWalkable(transform.position + velocity * Time.deltaTime * speed))
            {
                transform.position = transform.position + velocity * Time.deltaTime * speed;

            }

            velocity = new Vector3(0f, 0f, 0f);
        }
        else
        {
            image.SetActive(true);
            if (Input.GetKey("r"))
            {
                
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else if (Input.GetKey("q"))
            {
                SceneManager.LoadScene("Menu");
            }
        }
        



    }

    

    private bool isWalkable(Vector3 target)
    {
        if(Physics2D.OverlapCircle(target, 0.7f, solids) != null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    
    public void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "Key")
        {
            hasKey = true;
            keyPickUp.SetActive(true);
            Key.SetActive(false);
            if (soundFXOn)
            {
                SoundManagerScript.PlaySound("keypickup");
            }
            
        }
        if(collision.gameObject.tag == "Skeleton")
        {
            loseText.SetActive(true);
            if (soundFXOn)
            {
                SoundManagerScript.PlaySound("scream");
            }
            
            gameOver = true;
            player.transform.localScale = new Vector3(0, 0, 0);
            glowStickPrompt.SetActive(false);
            glowStickText.text = "";


        }
        if(collision.gameObject.tag == "Exit")
        {
            
            if (hasKey)
            {
                winText.SetActive(true);
                glowStickPrompt.SetActive(false);
                glowStickText.text = "";
                gameOver = true;
                player.transform.localScale = new Vector3(0, 0, 0);
            }
            else
            {
                keyNeededText.SetActive(true);
            }
        }
        
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Exit")
        {
            keyNeededText.SetActive(false);
        }
        
    }
}