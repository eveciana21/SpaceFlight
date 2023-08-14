using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SatelliteTrigger : MonoBehaviour
{
    [SerializeField] private PlayableDirector _satelliteDirector;
    [SerializeField] private GameObject _satelliteImage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Laser")
        {
            _satelliteDirector.Play();
            StartCoroutine(DestroyLapse());
        }
    }
    IEnumerator DestroyLapse()
    {
        yield return new WaitForSeconds(3);
        _satelliteImage.SetActive(false);
    }
}