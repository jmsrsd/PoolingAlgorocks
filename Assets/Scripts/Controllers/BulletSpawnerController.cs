using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

[DisallowMultipleComponent]
public class BulletSpawnerController : Controller
{
    public static int bulletCounter = 0;
    public MaxBulletSliderController maxBulletSlider;
    public TMP_Text bulletListText;
    public TMP_Text bulletCountNumberText;
    public TMP_Text bulletCountStopNumberText;
    public GameObject bulletPrefab;
    public float timer = 0.0f;

    public static float FiringRate
    {
        get => 60.0f / 1000.0f;
    }

    private static List<BulletController> Bullets
    {
        get => FindObjectsOfType<BulletController>().ToList();
    }

    private static List<BulletController> InactiveBullets
    {
        get
        {
            var result = Bullets.Where(b => b.stop).ToList();

            result.Sort((a, b) => a.createdTime.CompareTo(b.createdTime));

            return result;
        }
    }

    public override void Awake()
    {
        base.Awake();

        RegisterIntent(IntentType.LeftMouseButton, () =>
        {
            if (timer > Time.time)
            {
                return;
            }

            timer = Time.time + FiringRate;


            // Object Pooling
            if (InactiveBullets.Count < maxBulletSlider.Value)
            {
                bulletCounter++;
                
                var instantiated = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                instantiated.name = $"Bullet({bulletCounter})";
            }
            else
            {
                var bullet = InactiveBullets[0];
                bullet.gameObject.SetActive(false);
                bullet.gameObject.SetActive(true);
                bullet.transform.position = transform.position;
            }


        });
    }

    void Update()
    {
        bulletCountNumberText.text = Bullets.Count.ToString();
        bulletCountStopNumberText.text = InactiveBullets.Count.ToString();
        bulletListText.text = string.Join("\n", Bullets.Select(b => b.name).ToList());

        if (InactiveBullets.Count > maxBulletSlider.Value && Bullets.Count - InactiveBullets.Count == 0)
        {
            Destroy(InactiveBullets[0].gameObject);
        }
    }
}
