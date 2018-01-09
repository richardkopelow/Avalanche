using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform Camera;

    void Start()
    {
        float ratio = (float) Screen.height / (float) Screen.width;
        GlobalValues.GameHeight = GlobalValues.GameWidth * ratio;
        Camera.position = new Vector3(0, GlobalValues.GameHeight / 2, -10);
        Camera.GetComponent<Camera>().orthographicSize = GlobalValues.GameHeight / 2;
    }

    void Update()
    {

    }
}
