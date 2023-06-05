using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;

public class SoundManager : MonoBehaviour
{
    [Title("Info")]
    public Slider soundSlider;
    public TMP_InputField soundInput;
    public float soundSize;
    public Sprite[] soundSprites;
    public Image soundImage;

    AudioSource audio;

    void Awake(){
        audio = GetComponent<AudioSource>();
    }

    //슬라이더값에 변동이 생기면 뮤트여부이미지와 사운드사이즈텍스쳐에 값을 전달합니다.
    public void SoundSizeSilder(){
        soundSize = soundSlider.value;
        soundInput.text = soundSize.ToString();

        IsMute();
    }

    //사운드사이즈텍스쳐에 변동이 생기면 뮤트여부이미지와 슬라이더값에 값을 전달합니다.
    public void SoundController(){
        soundSize = float.Parse(soundInput.text);
        soundSlider.value = soundSize;
        IsMute();
    }

    //사운드를 실제적으로 조정합니다. AudioLisener를 조절하기떄문에, 변수값을 1로 기준을 잡았습니다.
    void IsMute(){
        GameManager.instance.soundSize = (soundSize / 100f);

        //무음여부에따라 무음이미지를 변경합니다.
        if(soundSize <= 0){
            GameManager.instance.isMute = true;
            soundImage.sprite = soundSprites[1];
        }
        else if(soundSize > 0){
            GameManager.instance.isMute = false;
            soundImage.sprite = soundSprites[0];
        }

        GameManager.instance.MuteSound();
        GameManager.instance.SoundChange();
    }

    //무음 여부에 따라 무음 이미지를 변경하고, 사운드를 무음화 시킵니다.
    public void OnMuteButton(){
        if(GameManager.instance.isMute == false){
            GameManager.instance.isMute = true;
            soundImage.sprite = soundSprites[1];
        }
        else if(GameManager.instance.isMute == true){
            GameManager.instance.isMute = false;
            soundImage.sprite = soundSprites[0];
        }
        GameManager.instance.MuteSound();
    }    
}
