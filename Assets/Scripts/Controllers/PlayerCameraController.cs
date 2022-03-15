using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerCameraController : Controller
{
    public override void Awake()
    {
        base.Awake();

        RegisterIntent(IntentType.LeftClick, () =>
        {
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                var clicked = hit.transform.gameObject;

                switch (clicked.name)
                {
                    case "Box":
                        ColorSingleton.Instance.color = Color.red;
                        break;
                    case "Ball":
                    ColorSingleton.Instance.color = Color.green;
                        break;
                    case "Capsule":
                    ColorSingleton.Instance.color = Color.blue;
                        break;
                    default:
                        break;
                }
            }
        });
    }
}
