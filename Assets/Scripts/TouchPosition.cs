//This script outputs the current position of a touch

//Attach this script to a GameObject
//Create a Text GameObject (Create>UI>Text)
//Attach the Text to the Text field in the Inspector window of your GameObject


using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TouchPosition : MonoBehaviour
{
    public Text m_Text;

    private void Start()
    {
        GUI.backgroundColor = Color.yellow;
    }

    void Update()
    {
        if (Input.touchCount == 0)
            return;

        Touch touch = Input.GetTouch(0);

        // Check if finger is over a UI element
        if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
        {
            m_Text.text = "Touched the UI!";
        }
        else
        {
            //Update the Text on the screen depending on current position of the touch each frame
            m_Text.text = "Touch Position : " + touch.position;
        }



    }
}