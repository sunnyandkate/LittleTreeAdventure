using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    NPC npc;

   

     //dialog
    [Header("Dialog")]
    public GameObject DialogBox;

    public Image dialogImage;
    public TextMeshProUGUI dialogText;  
    public bool dialogBoxIsOpenend = false;

    public GameObject menuScreen;
    public GameObject menuBtn;


    // Start is called before the first frame update
    void Start()
    {
          npc = FindObjectOfType<NPC>();
        //  menuScreen = GameObject.Find("Canvas/Menu");
          menuBtn = GameObject.Find("Canvas/MenuBtn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
     public void ActivateDialogBox(){
        DialogBox.SetActive(true);
        dialogBoxIsOpenend = true;
       
    }
    public void DeactivateDialogBox(){
        DialogBox.SetActive(false);
        dialogBoxIsOpenend = false;
    }
    public void OpenMenu(){
        menuScreen.SetActive(true);
        menuBtn.SetActive(false);
    }
    public void ContinueGame(){
        menuScreen.SetActive(false);
        menuBtn.SetActive(true);
    }
    public void QuitGame(){
        SceneManager.LoadScene("Title");
    }
}
