using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingAnimation : MonoBehaviour
{
    private float _anchorY, _timer;
    [SerializeField] private float _frequency = 0.1f, _amplitude = 20;
    public Coroutine FlotationCoroutine;

    private void Start()
    {
        _anchorY = transform.position.y;
        FlotationCoroutine = StartCoroutine(Floatation());
    }

    private IEnumerator Floatation()
    {
        while (true)
        {
            transform.position = new Vector3(transform.position.x, _anchorY + Mathf.Sin(_timer * _frequency) * _amplitude, transform.position.z);
            _timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}