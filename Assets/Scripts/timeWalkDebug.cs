using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class timeWalkDebug : MonoBehaviour
{
    public Text debugText;



    // Start is called before the first frame update
    void Start()
    {
        //var planeManager = GetComponent<ARPlaneManager>();
        //foreach (ARPlane plane in planeManager.trackables)
        //{
        //    // Do something with the ARPlane
        //}
        // debugText.text = "Testing";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void MyAction()
    {
        return;
    }
    void PlaneOnBoundaryChanged(ARPlaneBoundaryChangedEventArgs obj)
    {
        Debug.Log("boundary changed");
        debugText.text = "boundary changed";
    }
}
