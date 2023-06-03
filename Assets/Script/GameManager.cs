using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float soundSize;
    public bool isMute = false;

    void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this);
        }
        Destroy(this);
    }

    public void SoundChange(){
        AudioListener.volume = soundSize;
    }

    public void MuteSound(){
        AudioListener.pause = isMute;
    }
}
