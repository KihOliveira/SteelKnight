using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySineMovement : MonoBehaviour
{
    private float sinCenterY;
    [SerializeField] private float amplitude;
    [SerializeField] private float frequency;
    [SerializeField] private bool isInverted;
    void Start()
    {
        sinCenterY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        Vector2 pos = transform.position;
        float sin = Mathf.Sin(pos.x * frequency) * amplitude;
        if(isInverted){
            sin *= -1;
        }
        pos.y = sinCenterY + sin;
        transform.position = pos;
    }
}
