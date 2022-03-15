using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class BallController : Controller
{
    void Update()
    {
        gameObject.GetComponent<Renderer>().material.color = ColorSingleton.Instance.color;
    }
}
