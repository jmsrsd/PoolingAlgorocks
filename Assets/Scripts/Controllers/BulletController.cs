using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class BulletController : MonoBehaviour
{
    public GameObject sfxPrefab;
    public AudioClip fireAudioClip;
    public AudioClip hitAudioClip;

    public float createdTime = 0.0f;

    public float Speed
    {
        get => 240.0f;
    }
    public bool stop = false;

    void OnEnable()
    {
        var x = (Random.value * 2.0f) - 1.0f;
        var y = (Random.value * 2.0f) - 1.0f;
        var divisor = 16.0f;

        transform.forward = new Vector3(x / divisor, y / divisor, 1);
        stop = false;

        createdTime = Time.time;

        PlayAudioClip(fireAudioClip);
    }

    void Update()
    {
        if (stop)
        {
            return;
        }

        transform.position += transform.forward * Speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (stop)
        {
            return;
        }

        if (collision.gameObject.GetComponent<BulletController>() == null)
        {
            stop = true;

            PlayAudioClip(hitAudioClip);
        }
    }

    void PlayAudioClip(AudioClip audioClip)
    {
        var sfx = Instantiate(sfxPrefab, transform.position, Quaternion.identity).GetComponent<AudioSource>();
        sfx.pitch = Random.Range(0.8f, 1.0f);
        sfx.PlayOneShot(audioClip);
    }
}
