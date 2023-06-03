using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public string currentScene;
    public float maxTime = 3;
    public CanvasGroup optionCanvas;
    public Canvas uiCanvas;

    bool canClick = false;
    bool isOption;
    
    void Start(){
        currentScene = SceneManager.GetActiveScene().name;
        
        if(currentScene == "Main"){
            Invoke("CanClick", maxTime);
        }
    }

    void CanClick(){
        canClick = true;
    }
    public void OnChangeScene(int sceneNumber){
        if(canClick){
            SceneManager.LoadScene(sceneNumber);
        }
    }

    public void OnOptionBTN(){
        if(!isOption){
            if(uiCanvas != null){
                uiCanvas.gameObject.SetActive(false);
            }
            optionCanvas.gameObject.SetActive(true);
            isOption = true;
        }

        else if(isOption){
            if(uiCanvas != null){
                uiCanvas.gameObject.SetActive(true);
            }
            optionCanvas.gameObject.SetActive(false);
            isOption = false;
        }
    }



}
 