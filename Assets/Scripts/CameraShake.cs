using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private float _shakeDuration;
    private float _xShake, _yShake, _zShake;

    IEnumerator ShakeDuration()
    {
        Vector3 _originalPos = transform.position;
        _shakeDuration = Time.time + 0.2f;

        while (_shakeDuration > Time.time)
        {
            _xShake = Random.Range(-0.5f, 0.5f);
            _yShake = Random.Range(-0.5f, 0.5f);
            _zShake = Random.Range(-0.5f, 0.5f);
            transform.position = new Vector3(_xShake, _yShake, _zShake);
            yield return new WaitForEndOfFrame();
        }
        transform.position = _originalPos;
    }

    public void CameraShaking()
    {
        StartCoroutine(ShakeDuration());
    }
}
