using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chooseCanvas : MonoBehaviour
{
    public GameObject portraitCanvas;
    public GameObject landscapeCanvas;

    // Start is called before the first frame update
    void Start()
    {
        portraitCanvas.SetActive(true);
        landscapeCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        return;
#else

        if (Input.deviceOrientation == DeviceOrientation.Portrait || Input.deviceOrientation == DeviceOrientation.PortraitUpsideDown)
        {
            //codes for portrait
            portraitCanvas.SetActive(true);
            landscapeCanvas.SetActive(false);

        }
        else
        {
            //codes for Landspace;
            portraitCanvas.SetActive(false);
            landscapeCanvas.SetActive(true);

        }
#endif
    }
}
