using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Renderer bgRenderer;
    void Start()
    {
        
    }
    void Update()
    {
        bgRenderer.material.mainTextureOffset += new Vector2(speed*Time.deltaTime,0);
    }
}
