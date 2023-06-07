using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class PlaneAR : MonoBehaviour
{
    public GameObject gameObject;
    ARRaycastManager arRaycastManager;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();
    bool madeGoal = false;
   

    ARPlaneManager arPlane;

    void Start(){
        arRaycastManager = GetComponent<ARRaycastManager>();
        arPlane = GetComponent<ARPlaneManager>();
    }

    //처음 Plane포인트 위치에 오브젝트를 생성합니다. 목표물인 CageCat을 바닥에 생성해두기위한 스크립트입니다.
    //실행될시 게임이 준비되었다는 madeGoal을 true로합니다.
    void Update(){
        if(madeGoal == false){
            Vector3 centerPos = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
            
            arRaycastManager.Raycast(centerPos, hits, TrackableType.Planes);

            if(hits.Count > 0){
                Pose placePosition = hits[0].pose;
                gameObject.gameObject.SetActive(true);
                gameObject.transform.SetPositionAndRotation(placePosition.position, placePosition.rotation);
                madeGoal = true;
                Destroy(arRaycastManager);
                Destroy(arPlane);
            }
        } 
    }
}
