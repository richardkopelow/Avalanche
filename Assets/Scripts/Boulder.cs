using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{
    private Transform trans;
    private Rigidbody2D rigid;

    private float rotationRate;
    private Vector2 translationRate;

    void Start()
    {
        trans = GetComponent<Transform>();
        trans.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));
        rigid = GetComponent<Rigidbody2D>();
        rotationRate = Random.value * 50 + 20;
        translationRate = new Vector2(0, -2);
    }

    void Update()
    {
        rigid.rotation += rotationRate * Time.deltaTime;
        rigid.position += translationRate * Time.deltaTime;
    }
}
