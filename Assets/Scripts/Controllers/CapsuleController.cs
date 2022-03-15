using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class CapsuleController : Controller
{
    void Update()
    {
        gameObject.GetComponent<Renderer>().material.color = ColorSingleton.Instance.color;
    }
}
