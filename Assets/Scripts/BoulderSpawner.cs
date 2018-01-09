using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderSpawner : MonoBehaviour
{
    public Transform Boulder;

    private float spawnDensity = 10000;

    void Start()
    {

    }

    void Update()
    {
        float f = Random.value * spawnDensity;
        if (f < 100)
        {
            Spawn();
        }
        spawnDensity--;
    }

    private void Spawn()
    {
        Transform boulderTrans = Instantiate<Transform>(Boulder);
        boulderTrans.position = new Vector3((GlobalValues.GameWidth - 4) * (Random.value - 0.5f), GlobalValues.GameHeight + 1, 0);
    }
}
