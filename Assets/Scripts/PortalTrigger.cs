using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PortalTrigger : MonoBehaviour
{
    [SerializeField] private PlayableDirector _director;
    [SerializeField] private GameObject _pressRText;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SpaceShip")
        {
            _director.Play();
            _pressRText.SetActive(false);
        }
    }
}
