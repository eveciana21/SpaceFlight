using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;

public class ChangeCamera : MonoBehaviour
{
    [SerializeField] private GameObject _spaceShip;
    [SerializeField] private GameObject _cockpit;
    [SerializeField] private PlayableDirector _director;
    [SerializeField] private GameObject _mainCam;

    [SerializeField] private GameObject _cockpitCam, _spaceShipCam;

    [SerializeField] private bool _isCockpitCam;
    [SerializeField] private GameObject _trailParticles;
    [SerializeField] private bool _isPlayingCutScene;

    [SerializeField] private GameObject _pressRText;

    void Start()
    {
        //_mainCam.SetActive(false);

        if (_pressRText != null)
        {
            _pressRText.SetActive(false);
        }
        if (_cockpit != null)
        {
            _cockpit.SetActive(false);
        }
        if (_cockpitCam != null)
        {
            _cockpitCam.SetActive(false);
        }
        StartCoroutine(PressR());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (_isCockpitCam == false)
            {
                _pressRText.SetActive(true);
                _cockpitCam.SetActive(true);
                _cockpit.SetActive(true);
                _spaceShipCam.SetActive(false);
                _isCockpitCam = true;
            }
            else
            {
                _pressRText.SetActive(false);
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
                _spaceShipCam.SetActive(true);
                _cockpitCam.SetActive(false);
                _cockpit.SetActive(false);

                _director.Stop();
                _trailParticles.SetActive(false);
                StopCoroutine("PlayCutScene");
                StartCoroutine("PlayCutScene");

            }
            else
            {
                _pressRText.SetActive(false);
                _director.Stop();
                StopCoroutine("PlayCutScene");
            }
        }
    }

    IEnumerator PlayCutScene()
    {
        yield return new WaitForSeconds(10);
        _pressRText.SetActive(false);
        _cockpit.SetActive(false);
        _director.Play();

        /*if (_isCockpitCam == false)
        {
            _isCockpitCam = true;
        }*/
    }

    IEnumerator PressR()
    {
        yield return new WaitForSeconds(10);
        _pressRText.SetActive(true);
    }

    public void MainCam()
    {
        _mainCam.SetActive(true);
    }
}

