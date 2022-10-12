using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderEffect : MonoBehaviour
{
    private Vector3 originalY;

    private void Start()
    {
        originalY = transform.localPosition;
    }

    public void SetSlider(float delta)
    {
        transform.localPosition = Vector3.Lerp(originalY, new Vector3(originalY.x, -originalY.y, originalY.z), delta);
    }
}