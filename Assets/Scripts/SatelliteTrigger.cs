using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SatelliteTrigger : MonoBehaviour
{
    [SerializeField] private PlayableDirector _satelliteDirector;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Laser")
        {
            _satelliteDirector.Play();
        }
    }
}
