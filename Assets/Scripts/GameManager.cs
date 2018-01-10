using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform Camera;
    public Transform Background;

    private Material backgroundMat;

    void Start()
    {
        float ratio = (float)Screen.height / (float)Screen.width;
        GlobalValues.GameHeight = GlobalValues.GameWidth * ratio;
        Camera.position = new Vector3(0, GlobalValues.GameHeight / 2, -10);
        Camera.GetComponent<Camera>().orthographicSize = GlobalValues.GameHeight / 2;

        Background.position = new Vector3(0, GlobalValues.GameHeight / 2, 0);
        Background.localScale = new Vector3(GlobalValues.GameWidth, GlobalValues.GameHeight, 0);
        backgroundMat = Background.GetComponent<Renderer>().material;
        backgroundMat.SetFloat("_HalfWidth", GlobalValues.GameWidth / 2);

    }

    void Update()
    {
        bool pressed = Input.GetMouseButton(0);
        if (pressed)
        {
            GlobalValues.YOffset = Input.mousePosition.y * GlobalValues.GameHeight / Screen.height;
            backgroundMat.SetFloat("_YOffset", GlobalValues.YOffset);
            backgroundMat.SetFloat("_Slope", GlobalValues.Slope);
        }
    }
}
