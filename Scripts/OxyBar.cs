using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxyBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxOxy(float oxygen)
    {
        slider.maxValue = oxygen;
        slider.value = oxygen;
    }

    public void SetOxy(float oxygen)
    {
        slider.value = oxygen;
    }
}
