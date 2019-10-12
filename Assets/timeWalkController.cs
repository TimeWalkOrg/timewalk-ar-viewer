using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class timeWalkController : MonoBehaviour
{
    //define a list where the prefabs will be stored
    public static List<GameObject> myListObjects = new List<GameObject>();
    public static int numSpawned = 0;
    public static int numToSpawn = 3;
    public static int currentObjectIndex = 0;
    public static int objectsListLength = 0;
    public static GameObject currentObject;
    public static int incrementObject = 0;
    public Text objectNameText;
    public string objectNameString;

    void Start()
    {
        // NOTE: make sure all building prefabs are inside this folder: "Assets/Resources/Prefabs"

        Object[] subListObjects = Resources.LoadAll("Prefabs", typeof(GameObject));
        foreach (GameObject subListObject in subListObjects)
        {
            GameObject lo = (GameObject)subListObject;
            myListObjects.Add(lo);
            ++objectsListLength;
        }
        GameObject myObj = Instantiate(myListObjects[currentObjectIndex]) as GameObject;
        myObj.transform.parent = gameObject.transform;
        objectNameString = myObj.name;
        objectNameString = objectNameString.Substring(5);
        objectNameText.text = objectNameString.Replace("(Clone)", "");
        Debug.Log("New object: " + objectNameText.text);

        currentObject = myObj;


        //audioData = GetComponent<AudioSource>();
        //audioData.Play(0);
    }

    public void NextPrefab(int incrementValue)
    {

    //    if (EventSystem.current.IsPointerOverGameObject()) return;
        Debug.Log("clicked NEXT");
        SpawnNextObject(incrementValue);
    }

    public void SpawnNextObject(int incrementNumber)
    {
        Destroy(currentObject);
        currentObjectIndex = currentObjectIndex + incrementNumber;
        if (currentObjectIndex >= objectsListLength)
        {
            currentObjectIndex = 0;
        }

        if (currentObjectIndex < 0)
        {
            currentObjectIndex = objectsListLength - 1;
        }

        GameObject myObj = Instantiate(myListObjects[currentObjectIndex]) as GameObject;
        myObj.transform.parent = gameObject.transform; // set new myObj as child of current object?

        objectNameString = myObj.name;
        objectNameString = objectNameString.Substring(5);
        objectNameText.text = objectNameString.Replace("(Clone)", "");
        Debug.Log("New object: " + objectNameText.text);
        // myObj.transform.position = transform.position; // NO: instead we will use the object's default position
        currentObject = myObj;
        Debug.Log("currentObjectIndex = " + currentObjectIndex);
    }

    void Update()
    {
    }

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    ARRaycastManager m_RaycastManager;

}
