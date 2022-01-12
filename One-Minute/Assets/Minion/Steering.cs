using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steering : MonoBehaviour
{
    public float angular;
    public Vector2 linear;
    public Steering()
    {
        angular = 0f;
        linear = new Vector2();
    }
}
