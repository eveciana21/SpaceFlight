using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;

public class ChangeCamera : MonoBehaviour
{
    [SerializeField] private GameObject _cockpit;
    [SerializeField] private PlayableDirector _director;

    [SerializeField] private GameObject _cockpitCam, _spaceShipCam;

    [SerializeField] private bool _isCockpitCam;

    void Start()
    {
        _cockpitCam.SetActive(false);
        _cockpit.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (_isCockpitCam == false)
            {
                _cockpitCam.SetActive(true);
                _cockpit.SetActive(true);
                _spaceShipCam.SetActive(false);
                _isCockpitCam = true;
            }
            else
            {
                _cockpitCam.SetActive(false);
                _cockpit.SetActive(false);
                _spaceShipCam.SetActive(true);
                _isCockpitCam = false;
            }
        }

        if (Input.anyKeyDown || Input.anyKey)
        {
            if (_isCockpitCam == false)
            {
                _director.Stop();
                StopCoroutine("PlayCutScene");
                StartCoroutine("PlayCutScene");
            }
            else
            {
                StopCoroutine("PlayCutScene");
            }
        }
    }

    IEnumerator PlayCutScene()
    {
        yield return new WaitForSeconds(2);
        _cockpit.SetActive(false);
        _director.Play();

        if (_isCockpitCam == false)
        {
            _isCockpitCam = true;
        }
    }
}

