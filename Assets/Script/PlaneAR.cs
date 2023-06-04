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

    void Update(){
        
            Vector3 centerPos = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
            
            arRaycastManager.Raycast(centerPos, hits, TrackableType.PlaneWithinPolygon);

            if(hits.Count > 0){
                Pose placePosition = hits[0].pose;
                gameObject.gameObject.SetActive(true);
                gameObject.transform.SetPositionAndRotation(placePosition.position, placePosition.rotation);
                madeGoal = true;
            }
        
    } 
}
