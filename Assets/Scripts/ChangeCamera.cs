using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;


public class ChangeCamera : MonoBehaviour
{
    [SerializeField] private GameObject _spaceShip;
    [SerializeField] private GameObject _cockpit;
    [SerializeField] private PlayableDirector _director, _controlsDirector;
    [SerializeField] private GameObject _mainCam;

    [SerializeField] private GameObject _cockpitCam, _spaceShipCam;

    [SerializeField] private bool _isCockpitCam;
    [SerializeField] private GameObject _trailParticles;
    [SerializeField] private bool _isPlayingCutScene;

    [SerializeField] private GameObject _cutSceneText;

    [SerializeField] private CinemachineExtension _zoomCam;

    [SerializeField] private ShipControls _shipControls;

    [SerializeField] private GameObject _satRemainingImage;

    [SerializeField] private GameObject _missionStatement;
    [SerializeField] private bool _canStartPlaying;

    [SerializeField] private bool _satelliteImageDisabled;

    [SerializeField] private bool _canPlayCutScene = true;

    [SerializeField] private GameObject _mouseToLookText;

    void Start()
    {
        StartCoroutine(MissionStatement());

        _shipControls = _shipControls.GetComponent<ShipControls>();
        _spaceShip.SetActive(true);
        _satRemainingImage.SetActive(false);
        _zoomCam.enabled = false;

        if (_cutSceneText != null)
        {
            _cutSceneText.SetActive(false);
        }
        if (_cockpit != null)
        {
            _cockpit.SetActive(false);
        }
        if (_cockpitCam != null)
        {
            _cockpitCam.SetActive(false);
        }

        _zoomCam.enabled = false;
    }

    void Update()
    {
        ChangeCameraView();

        if (_canStartPlaying == true)
        {
            if (_isCockpitCam == false)
            {
                if (Input.GetKey(KeyCode.F))
                {
                    _zoomCam.enabled = true;
                }
                if (Input.GetKeyUp(KeyCode.F))
                {
                    _zoomCam.enabled = false;
                }
            }
        }

        if (_isCockpitCam == false && _canStartPlaying == true && _isPlayingCutScene == false)
        {
            _satRemainingImage.SetActive(true);
        }
        if (_satelliteImageDisabled == true)
        {
            _satRemainingImage.SetActive(false);
        }
    }


    IEnumerator PlayCutScene()
    {
        yield return new WaitForSeconds(20);
        _isPlayingCutScene = true;
        _isCockpitCam = false;
        _satRemainingImage.SetActive(false);
        _mouseToLookText.SetActive(false);
        _cutSceneText.SetActive(false);
        _cockpit.SetActive(false);
        _spaceShip.SetActive(true);
        _director.Play();
    }

    private void SpaceShipCam()
    {
        _spaceShipCam.SetActive(true);
        _cockpitCam.SetActive(false);
        _cockpit.SetActive(false);
        _mouseToLookText.SetActive(false);
        _cutSceneText.SetActive(true);
        _director.Stop();
        _trailParticles.SetActive(false);

        if (_canPlayCutScene == true)
        {
            StopCoroutine("PlayCutScene");
            StartCoroutine("PlayCutScene");
        }
        else
        {
            StopCoroutine("PlayCutScene");
        }
    }

    private void CockPitCam()
    {
        _cutSceneText.SetActive(true);
        _satRemainingImage.SetActive(false);
        _mouseToLookText.SetActive(true);
        _director.Stop();

        if (_canPlayCutScene == true)
        {
            StopCoroutine("PlayCutScene");
            StartCoroutine("PlayCutScene");
        }
        else
        {
            StopCoroutine("PlayCutScene");
        }
    }

    IEnumerator MissionStatement()
    {
        _missionStatement.SetActive(false);
        yield return new WaitForSeconds(7);
        _missionStatement.SetActive(true);
        yield return new WaitForSeconds(9);
        _missionStatement.SetActive(false);
        _canStartPlaying = true; // can now press inputs
        yield return new WaitForSeconds(3);
        _satRemainingImage.SetActive(true);
        _controlsDirector.Play();
    }

    private void ChangeCameraView()
    {
        if (_canStartPlaying == true)
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                _isPlayingCutScene = false;

                if (_isCockpitCam == false)
                {
                    _spaceShip.SetActive(false);
                    _spaceShipCam.SetActive(false);
                    _cockpitCam.SetActive(true);
                    _cockpit.SetActive(true);
                    _cutSceneText.SetActive(true);
                    _isCockpitCam = true;
                }
                else
                {
                    _spaceShip.SetActive(true);
                    _spaceShipCam.SetActive(true);
                    _cockpitCam.SetActive(false);
                    _cockpit.SetActive(false);
                    _cutSceneText.SetActive(false);
                    _isCockpitCam = false;
                }
            }

            if (Input.anyKeyDown || Input.anyKey)
            {
                _isPlayingCutScene = false;

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
    }
    public void IsPlayingCutScene()
    {
        _isPlayingCutScene = true;
    }

    public void IsNotPlayingCutScene()
    {
        _isPlayingCutScene = false;
    }

    public void SatelliteImageDisabled()
    {
        _satelliteImageDisabled = true;
    }

    public void CutSceneDisabled()
    {
        _cutSceneText.SetActive(false);
        _mouseToLookText.SetActive(false);
        _satRemainingImage.SetActive(false);
        _canPlayCutScene = false;
    }
}