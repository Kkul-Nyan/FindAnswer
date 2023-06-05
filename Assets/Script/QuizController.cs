using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuizController : MonoBehaviour
{   
    public TMP_InputField answer1;
    public TMP_InputField answer2;
    public TMP_InputField answer3;
    public Canvas answerCanvas;
    public Canvas finishCanvas;
    public CanvasGroup wrongImage;
    public TextMeshProUGUI clearTimeText;
    bool isAnswer =false;
    bool isWrong = false;
    bool isClear = false;
    float wrongTime;
    float maxTime = 2;
    float clearTime;


    public GameObject cageCat;
    public GameObject cage;

    public Camera camera;
    public Vector3 offset = new Vector3(0,0,1);
    Renderer renderer;
    float dessolveTime;
    bool isDessolve = false;

    private void Start() {
        renderer = cage.GetComponent<Renderer>();
    }
    private void Update() {
        CheckisWrong();
        ClearTimeCheck();
        DessolveCage();
    }

    public void OnKeyBTN(){
        if(!isAnswer){
            answerCanvas.gameObject.SetActive(true);
            isAnswer = true;
        }
        else if(isAnswer){
            answerCanvas.gameObject.SetActive(false);
            isAnswer = false;
        }
    }
    public void ClearTimeCheck(){
        if(!isClear){
            clearTime += Time.deltaTime;
        }
        else{
            clearTimeText.text = "Clear Time : " + clearTime;
        }   
    }
    //Wrong이미지를 2초간 띄운뒤 꺼집니다.
    void CheckisWrong(){
        if(isWrong && wrongTime > 0){
            wrongTime -= Time.deltaTime;
            wrongImage.alpha = Mathf.Lerp(0, maxTime, wrongTime);
        }
        else if(isWrong && wrongTime <= 0){
            wrongTime = maxTime;
            wrongImage.gameObject.SetActive(false);
            isWrong = false;
            wrongImage.alpha = 1;
        }
    }
    //정답을 눌렸을때, 작동합니다. 정답을 맞추면 승리캔버스가열리고, 오답시 답을 초기화하고 실패 스크립틀을 작동합니다
    public void OnSubmitBTN(){
        if(answer1.text == "숭례문" && answer2.text == "다이아몬드" && answer3.text == "바나나킥"){
            answerCanvas.gameObject.SetActive(false);
            finishCanvas.gameObject.SetActive(true);
            isClear = true;
            cageCat.transform.position = camera.transform.position + offset;
            Invoke("Dessolve", 1f);
        }
        else {
            answer1.text = "";
            answer2.text = "";
            answer3.text = "";
            wrongImage.gameObject.SetActive(true);
            isWrong = true;
        }
    }

    void Dessolve(){
        isDessolve = true;
    }

    void DessolveCage(){
        if(isDessolve){
            cageCat.transform.position = camera.transform.position + offset;
            renderer.material.SetFloat("_DessolvePower", dessolveTime );
            dessolveTime += (Time.deltaTime / 10);
        }
    }
}
