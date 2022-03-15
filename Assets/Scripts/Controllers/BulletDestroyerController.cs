using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class BulletDestroyerController : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        var go = collision.gameObject;
        var controller = go.GetComponent<BulletController>();

        if (controller != null)
        {
            controller.stop = true;
            controller.transform.position = Vector3.back * -1000.0f;
        }
    }
}
