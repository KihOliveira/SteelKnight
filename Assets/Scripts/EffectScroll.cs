using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectScroll : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private RawImage img;

    void Update()
    {
        img.uvRect = new Rect(img.uvRect.position + new Vector2 (speed*Time.deltaTime,0) * Time.deltaTime,img.uvRect.size);
    }
}
