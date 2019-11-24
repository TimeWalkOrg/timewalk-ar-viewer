using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoosePrefab : MonoBehaviour
{


    public static List<GameObject> myListObjects = new List<GameObject>(); // list where prefabs will be stored
    public static int currentObjectIndex = 0;
    public static int objectsListLength = 0;
    public static GameObject currentObject;
    public static GameObject temporaryObject;
    private Text modelNameText;
    private Text debugText;
    private string objectNameString;
    private Button nextPrefabButton;
    private Button previousPrefabButton;
    private Button fireworksButton;
    private ParticleSystem fireworksParticleSystem;




    // Start is called before the first frame update
    void Start()
    {
        debugText = GameObject.Find("Debug Text").GetComponent<Text>();

        modelNameText = GameObject.Find("Model Name").GetComponent<Text>();
        modelNameText.text = ""; // blank name until placed

        nextPrefabButton = GameObject.Find("Next Prefab button").GetComponent<Button>();
        previousPrefabButton = GameObject.Find("Previous Prefab button").GetComponent<Button>();
        fireworksButton = GameObject.Find("Fireworks Launch button").GetComponent<Button>();


        this.nextPrefabButton.onClick.AddListener(this.GetNextPrefab); // replace model with next (or previous)
        this.previousPrefabButton.onClick.AddListener(this.GetPreviousPrefab); // replace model with next (or previous)

        this.fireworksButton.onClick.AddListener(this.LaunchFireworks); // fireworks launch callback



        // NOTE: make sure all building prefabs are inside this folder: "Assets/Resources/TimeWalk Prefabs"

        Object[] subListObjects = Resources.LoadAll("TimeWalk Prefabs", typeof(GameObject));
        foreach (GameObject subListObject in subListObjects)
        {
            GameObject lo = (GameObject)subListObject;
            temporaryObject = Instantiate(lo) as GameObject;
            temporaryObject.transform.parent = this.gameObject.transform; // make instantiated object a child of the current Object
            temporaryObject.transform.gameObject.SetActive(false); // hide each object for now
            myListObjects.Add(temporaryObject);
            ++objectsListLength;
        }

        // Now enable the first (0th) object
        currentObjectIndex = 0;
        myListObjects[currentObjectIndex].transform.gameObject.SetActive(true);
        modelNameText.text = ModelName(myListObjects[currentObjectIndex]);
    }

    public void GetNextPrefab()
    {
        ShowSelectedPrefab(+1);
        //debugText.text = "Next: currentObjectIndex = " + currentObjectIndex;

    }

    public void GetPreviousPrefab()
    {
        ShowSelectedPrefab(-1);
        //debugText.text = "Previous: currentObjectIndex = " + currentObjectIndex;

    }
    public void ShowSelectedPrefab(int increment)
    {
        // hide the currentObject
        myListObjects[currentObjectIndex].transform.gameObject.SetActive(false);

        currentObjectIndex = currentObjectIndex + increment;
        if (currentObjectIndex >= objectsListLength)
        {
            currentObjectIndex = 0;
        }

        if (currentObjectIndex < 0)
        {
            currentObjectIndex = objectsListLength - 1;
        }
        myListObjects[currentObjectIndex].transform.gameObject.SetActive(true);
        //debugText.text = "Selected: " + myListObjects[currentObjectIndex].transform.gameObject.name;
        modelNameText.text = ModelName(myListObjects[currentObjectIndex]);

    }

    public string ModelName(GameObject prefabObject)
    {
        objectNameString = prefabObject.name;
        objectNameString = objectNameString.Substring(5);
        objectNameString = objectNameString.Replace("(Clone)", "");
        return objectNameString;

    }

    void LaunchFireworks()
    {
        GameObject fireworksTest = GameObject.Find("Fireworks");
        //fireworksParticleSystem = GameObject.Find("Fireworks").GetComponent<ParticleSystem>();
        if (fireworksTest != null)
        {
            fireworksParticleSystem = fireworksTest.GetComponent<ParticleSystem>();
            fireworksParticleSystem.Play();
            debugText.text = "Fireworks!";
        }
        //debugText.text = "";

    }
}
