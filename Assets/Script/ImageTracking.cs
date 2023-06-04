using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.XR.ARFoundation;


public class ImageTracking : MonoBehaviour
{
 
    private ARTrackedImageManager trackedImageManager;

    [SerializeField]
    [Title("Prefabs")]
    [PreviewField(80, ObjectFieldAlignment.Center)]
    private GameObject[] trackedObjects;
    private Dictionary<string, GameObject> spawnedObjects;

    void Awake(){
        trackedImageManager = GetComponent<ARTrackedImageManager>();
        spawnedObjects = new Dictionary<string, GameObject>();

        foreach(GameObject obj in trackedObjects){
            GameObject newObject = Instantiate(obj);
            newObject.name = obj.name;
            newObject.SetActive(false);

            spawnedObjects.Add(newObject.name, newObject);
        }
    }

    void OnEnable(){
        trackedImageManager.trackedImagesChanged += OnTrackedImageChanged;
    }

    void OnDisable(){
        trackedImageManager.trackedImagesChanged -= OnTrackedImageChanged;
    }
    void OnTrackedImageChanged(ARTrackedImagesChangedEventArgs eventArgs){
        foreach(ARTrackedImage trackedImage in eventArgs.added){
            UpdateSpawnObject(trackedImage);
        }
        foreach(ARTrackedImage trackedImage in eventArgs.updated){
            UpdateSpawnObject(trackedImage);
        }
        foreach(ARTrackedImage trackedImage in eventArgs.removed){
            spawnedObjects[trackedImage.name].SetActive(false);
        }
    }
    
    void UpdateSpawnObject(ARTrackedImage trackedImage){
        string referImageName = trackedImage.referenceImage.name;
        spawnedObjects[referImageName].transform.position = trackedImage.transform.position;
        spawnedObjects[referImageName].transform.rotation = trackedImage.transform.rotation;

        spawnedObjects[referImageName].SetActive(true);
    }
}

