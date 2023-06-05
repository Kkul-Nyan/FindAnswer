using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float soundSize;
    public bool isMute = false;

    //사운드사이즈 값을 씬마다 변동되는것을 막기위해 싱글톤화 했습니다.
    void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this);
        }
        Destroy(this);
    }
    //SoundManager스크립트에서 변동이 생길시 게임매니저에서 사운드를 적용합니다.
    public void SoundChange(){
        AudioListener.volume = soundSize;
    }

    //SoundManager스크립트에서 음소거 여부를 변수에 변동이 생기면 게임매니저에서 사운드를 적용합니다.
    public void MuteSound(){
        AudioListener.pause = isMute;
    }
}
