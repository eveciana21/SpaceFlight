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

    [SerializeField] private CinemachineExtension _zoomCam;

    [SerializeField] private ShipControls _shipControls;


    void Start()
    {
        _shipControls = _shipControls.GetComponent<ShipControls>();
        _spaceShip.SetActive(true);

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

        _zoomCam.enabled = false;
    }

    void Update()
    {
        if (_isCockpitCam == false)
        {
            if (Input.GetKey(KeyCode.T))
            {
                _zoomCam.enabled = true;
            }
            if (Input.GetKeyUp(KeyCode.T))
            {
                _zoomCam.enabled = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (_isCockpitCam == false)
            {

                _spaceShip.SetActive(false);
                _pressRText.SetActive(true);
                _cockpitCam.SetActive(true);
                _cockpit.SetActive(true);
                _spaceShipCam.SetActive(false);
                _isCockpitCam = true;
            }
            else
            {
                _spaceShip.SetActive(true);
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
                _shipControls.CockpitCamNotActive();
                SpaceShipCam();
            }
            else
            {
                _shipControls.CockpitCamActive();
                CockPitCam();
            }
        }
    }

    IEnumerator PlayCutScene()
    {
        yield return new WaitForSeconds(5);
        _isCockpitCam = false;
        _pressRText.SetActive(false);
        _cockpit.SetActive(false);
        _spaceShip.SetActive(true);
        _director.Play();
    }

    IEnumerator PressR()
    {
        yield return new WaitForSeconds(5);
        _pressRText.SetActive(true);
    }

   /*public void MainCam()
    {
        _mainCam.SetActive(true);
    }*/

    private void SpaceShipCam()
    {
        _spaceShipCam.SetActive(true);
        _cockpitCam.SetActive(false);
        _cockpit.SetActive(false);
        _pressRText.SetActive(true);
        _director.Stop();
        _trailParticles.SetActive(false);
        StopCoroutine("PlayCutScene");
        StartCoroutine("PlayCutScene");
    }

    private void CockPitCam()
    {
        _pressRText.SetActive(false);
        _director.Stop();
        StopCoroutine("PlayCutScene");
        StartCoroutine("PlayCutScene");
    }
}

