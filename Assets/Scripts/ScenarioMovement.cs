using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioMovement : MonoBehaviour
{
    [SerializeField] private int speed;

    void Update()
    {
        transform.Translate(Vector3.left *speed * Time.deltaTime);
    }
}
