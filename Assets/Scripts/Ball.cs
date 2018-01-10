using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int Side = 1;

    private float time;
    private float yOffset;
    private float slope;

    private Rigidbody2D rigid;


    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        setup();
    }

    private void setup()
    {
        time = 0;
        Side *= -1;
        slope = GlobalValues.Slope;
        yOffset = GlobalValues.YOffset;
    }

    void Update()
    {
        if (time > GlobalValues.BounceDuration)
        {
            setup();
        }
        time += Time.deltaTime;
        float x = Side * (time / GlobalValues.BounceDuration - 0.5f) * GlobalValues.GameWidth;
        float y = slope * x * x + yOffset;
        rigid.position = new Vector2(x, y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.otherRigidbody.gameObject.tag)
        {
            case "Boulder":

                break;
            default:
                break;
        }
    }

    private void End()
    {

    }
}
