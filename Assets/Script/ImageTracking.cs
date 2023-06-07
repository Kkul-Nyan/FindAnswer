using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.XR.ARFoundation;

//멀티 이미지 트레킹을 하는 스크립트입니다.
public class ImageTracking : MonoBehaviour
{

    private ARTrackedImageManager trackedImageManager;

    [SerializeField]
    private GameObject[] trackedObjects;
    private Dictionary<string, GameObject> spawnedObjects;
    public float offset = 90;

    void Awake(){
		//변수들을 초기화합니다. 이미지트레킹에 사용될 오브젝트를 미리생성한뒤 SetActive를꺼줍니다.
		//게임도중에 렉이 걸리는것을 방지할려고했습니다.
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

		//이미지가 새로추가되거나, 위치값이 변동되거나, 아예사라질경우 작동하는 스크립트입니다.
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
    // 딕셔너리를 이용하여 맞는 오브젝트를 실행합니다(SetActive(true))
		// 이를 위해 딕셔너리 string값과 오브젝트의 이름을 똑같이 만들어주었습니다.
    
    void UpdateSpawnObject(ARTrackedImage trackedImage){
        Quaternion quaternion = Quaternion.identity;
        string referImageName = trackedImage.referenceImage.name;
        spawnedObjects[referImageName].transform.position = trackedImage.transform.position;
        spawnedObjects[referImageName].transform.rotation =  trackedImage.transform.rotation;
        spawnedObjects[referImageName].transform.Rotate(trackedImage.transform.rotation.x + offset, trackedImage.transform.rotation.y, trackedImage.transform.rotation.z);

        spawnedObjects[referImageName].SetActive(true);
    }
}