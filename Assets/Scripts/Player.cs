using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    //movement
    public float moveSpeed;
   
    float xInput;
    float yInput;
    private Vector2 moveDirection;

    private GameManager gameManager;
    private Animator animator;
    private SceneChanger sceneChanger;

    //collect soil and water
    public bool hasSoil;
    public bool hasWater;

    public static Player instance;

    public AreaTransition playerStartPosition;

    void Awake(){
   //check if the player already exists
            if(instance == null){
            instance = this;
            
        }
        else if(instance != this){
            Destroy(gameObject);
        }  
         DontDestroyOnLoad(gameObject);  
     
       
   }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
     //   spriteRenderer = GetComponent<SpriteRenderer>();
        gameManager = FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();
        sceneChanger = FindObjectOfType<SceneChanger>();

        transform.position = playerStartPosition.AreaTransitionValue;
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void FixedUpdate(){
            //player movement   
            xInput = Input.GetAxis("Horizontal");
            yInput = Input.GetAxis("Vertical");
            transform.Translate(xInput * moveSpeed * Time.deltaTime, yInput * moveSpeed * Time.deltaTime, 0f);     
            MovePlayer();              
    }
   
    private void MovePlayer(){
        //idle animation
        animator.SetBool("Walk", false);
              
        if(xInput != 0 || yInput != 0){
            //walking animation
            animator.SetBool("Walk", true);
            animator.SetFloat("MoveX", xInput);
            animator.SetFloat("MoveY", yInput);
        } 
    }
    public void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Soil"){
            hasSoil = true;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Water"){
            hasWater = true;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Sun"){
            if(hasSoil && hasWater){
                if(transform.localScale.x == 1f){
                    //  transform.localScale = new Vector3(2f, 2f, 2f);
                     Invoke("LoadEndScene", 1.5f);
                    
                }else{
                    transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
                }
               
                hasSoil = false;
                hasWater = false;
            }
        }      
    }
    public void LoadEndScene(){
        transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        SceneManager.LoadScene("GameEnd");
    }
    public void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "SceneChanger"){
            transform.position = playerStartPosition.AreaTransitionValue;
        }
    }
}
