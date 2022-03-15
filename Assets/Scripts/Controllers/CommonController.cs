using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class CommonController : Controller
{
    public override void Awake()
    {
        base.Awake();

        RegisterIntent(IntentType.Escape, () => {
            Debug.Log("Quit Game");
            Application.Quit();
        });
    }
}
