using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
      //screens
    [Header("Screens")]
    public GameObject TitleScreen;

    public GameObject FadeInCanvas;

    public string sceneToLoad;
    // Start is called before the first frame update
    void Start()
    {
            TitleScreen = GameObject.Find("Canvas/TitleScreen");
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void StartGame(){
        FadeInCanvas.SetActive(true);
        TitleScreen.SetActive(false);
        Invoke("SelectLevel", 1.5f);
        Invoke("FadeOut", 1.8f); 
    }
     public void SelectLevel(){    
        SceneManager.LoadScene(sceneToLoad);     
   }
    public void FadeOut(){
      FadeInCanvas.SetActive(false);
       
   }
    public void QuitGame(){
        SceneManager.LoadScene("Credits");
    }
    public void CloseGame(){
       // Application.Quit();
    }
}
