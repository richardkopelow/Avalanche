using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform Camera;

    private bool wasPressed;
    private float lastMousePos = 0;

    void Start()
    {
        float ratio = (float)Screen.height / (float)Screen.width;
        GlobalValues.GameHeight = GlobalValues.GameWidth * ratio;
        Camera.position = new Vector3(0, GlobalValues.GameHeight / 2, -10);
        Camera.GetComponent<Camera>().orthographicSize = GlobalValues.GameHeight / 2;
    }

    void Update()
    {
        bool pressed = Input.GetMouseButton(0);
        if (pressed)
        {
            if (!wasPressed)
            {
                lastMousePos = Input.mousePosition.y;
            }
            float delta = Input.mousePosition.y - lastMousePos;
            delta *= GlobalValues.GameHeight / Screen.height;
            GlobalValues.YOffset += delta;
            lastMousePos = Input.mousePosition.y;
        }
        wasPressed = pressed;
    }
}
