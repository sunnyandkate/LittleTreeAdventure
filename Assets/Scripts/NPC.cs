using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    Player player;
    GameManager gameManager;
    bool talkNPC = false;

    public Sprite npcImage;
    public string[] currentText;
       
    int dialogLine;
   
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
       
        //activate dialogbox
         if(Input.GetKeyDown(KeyCode.Return) && talkNPC == true){            
                gameManager.ActivateDialogBox();
            if(gameManager.dialogBoxIsOpenend){
                TalkingNPC();                
            }
        }       
    }
    public void TalkingNPC(){
      
       if(dialogLine >= currentText.Length){           
            return;
       }
       gameManager.dialogText.text = currentText[dialogLine];
       dialogLine++;              
    }
    
    public void ChangeDialogImage(){
        gameManager.dialogImage.sprite = npcImage;
    }
    public void OnCollisionEnter2D(Collision2D other){
        //if player is talking to an npc
        if(other.gameObject.tag == "Player"){
            talkNPC = true;
            ChangeDialogImage();
        }
    }
    public void OnCollisionExit2D(Collision2D other){
        //if player is leaving npc area
        if(other.gameObject.tag == "Player"){
            talkNPC = false;
            gameManager.DeactivateDialogBox();
            dialogLine = 0;            
        }
    }    
}
