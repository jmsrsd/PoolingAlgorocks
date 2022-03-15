using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class BoxController : Controller
{
    void Update()
    {
        gameObject.GetComponent<Renderer>().material.color = ColorSingleton.Instance.color;
    }
}
