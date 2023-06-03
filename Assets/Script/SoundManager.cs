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

    public void SoundSizeSilder(){
        soundSize = soundSlider.value;
        soundInput.text = soundSize.ToString();

        IsMute();
    }

    public void SoundController(){
        soundSize = float.Parse(soundInput.text);
        soundSlider.value = soundSize;
        IsMute();
    }

    void IsMute(){
        GameManager.instance.soundSize = (soundSize / 100f);

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
