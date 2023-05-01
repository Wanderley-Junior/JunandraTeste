using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSin : MonoBehaviour
{
    float sinCenterY;
    public float amplitude = 2;
    public float frequency = 2;

    public bool inverted = false;

    void Start()
    {
        sinCenterY = transform.position.y;
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        float sin = Mathf.Sin(pos.x * frequency) * amplitude;
        if (inverted)
        { //sin recebe o valor da multiplicacao por -1
            sin *= -1;
        }
        pos.y = sinCenterY + sin;

        transform.position = pos;
    }
}