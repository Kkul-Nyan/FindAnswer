using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public string currentScene;
    public float maxTime = 3;
    public CanvasGroup optionCanvas;
    public Canvas uiCanvas;

    bool canClick = false;
    bool isOption;
    
    //현재씬이 메인씬이면, 게임시작버튼 작동을 maxtime이후에 가능하게합니다.(애니메이션과 동기화)
    void Start(){
        currentScene = SceneManager.GetActiveScene().name;
        
        if(currentScene == "Main"){
            Invoke("CanClick", maxTime);
        }
        else{
            CanClick();
        }
    }
    //Invoke로 통제하기위해 림다식으로 간단히 구성했습니다.
    void CanClick() => canClick = true;

    //씬 변경 버튼마다 여러개의 스크립트 작성을 막기위해, 씬번호를 넣도록만들었습니다.
    public void OnChangeScene(int sceneNumber){
        if(canClick){
            SceneManager.LoadScene(sceneNumber);
        }
    }

    //옵션버튼을 눌렸을때, 옵션창이 켜져있으면 꺼지게되고, 꺼져있으면 켜지게 됩니다.
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
 