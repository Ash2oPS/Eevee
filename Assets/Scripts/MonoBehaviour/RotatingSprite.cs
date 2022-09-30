using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingSprite : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 1f;
    [SerializeField] private bool _isAdditive = false;
    private float _anchorY, _timer;
    [SerializeField] private float _frequency = 0.1f, _amplitude = 20;

    private void Start()
    {
        if (!_isAdditive)
        {
            StartCoroutine(Rotation());
            return;
        }

        StartCoroutine(RotationAdditive());
    }

    private IEnumerator Rotation()
    {
        while (true)
        {
            transform.Rotate(new Vector3(0, 0, 1) * _rotationSpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator RotationAdditive()
    {
        while (true)
        {
            //transform.Rotate(new Vector3(0, 0, 1) * _rotationSpeed * Time.deltaTime);

            transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Sin(_timer * _frequency) * _amplitude);
            _timer += Time.deltaTime * _rotationSpeed;

            yield return new WaitForEndOfFrame();
        }
    }
}