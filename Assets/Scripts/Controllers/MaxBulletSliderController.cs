using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MaxBulletSliderController : MonoBehaviour
{
    public TMP_Text numberText;

    public int Value {
        get {
            return (int) GetComponent<Slider>().value;
        }
    }

    void Update() {
        numberText.text = Value.ToString();
    }
}
