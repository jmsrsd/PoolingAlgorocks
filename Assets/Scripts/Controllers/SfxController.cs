using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxController : MonoBehaviour
{
    void Update()
    {
        var audioSource = GetComponent<AudioSource>();

        if (audioSource.isPlaying == false) {
            Destroy(gameObject);
        }
    }
}
