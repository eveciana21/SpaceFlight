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

    [SerializeField] private GameObject _satRemainingImage;

    [SerializeField] private GameObject _missionStatement;
    private bool _canStartPlaying;

    private bool _satelliteImageDisabled;


    void Start()
    {
        StartCoroutine(MissionStatement());
        StartCoroutine(CanStartPlaying());

        _shipControls = _shipControls.GetComponent<ShipControls>();
        _spaceShip.SetActive(true);
        _satRemainingImage.SetActive(false);
        _zoomCam.enabled = false;

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

        _zoomCam.enabled = false;
    }

    void Update()
    {
        ChangeCameraView();

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

        if (_isPlayingCutScene == true)
        {
            _satRemainingImage.SetActive(false);
        }
    }

    IEnumerator PlayCutScene()
    {
        yield return new WaitForSeconds(10);
        _isPlayingCutScene = true;
        _isCockpitCam = false;
        _pressRText.SetActive(false);
        _cockpit.SetActive(false);
        _spaceShip.SetActive(true);
        _director.Play();
    }

    private void SpaceShipCam()
    {
        if (_satelliteImageDisabled == false)
        {
            _satRemainingImage.SetActive(true);
        }
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
        _satRemainingImage.SetActive(false);
        _director.Stop();
        StopCoroutine("PlayCutScene");
        StartCoroutine("PlayCutScene");
    }


    IEnumerator MissionStatement()
    {
        _missionStatement.SetActive(false);
        yield return new WaitForSeconds(7);
        _missionStatement.SetActive(true);
        yield return new WaitForSeconds(7);
        _missionStatement.SetActive(false);
        yield return new WaitForSeconds(3);
        _satRemainingImage.SetActive(true);
        _pressRText.SetActive(true);
    }

    IEnumerator CanStartPlaying()
    {
        yield return new WaitForSeconds(14);
        _canStartPlaying = true; //can press inputs
    }

    private void ChangeCameraView()
    {
        if (_canStartPlaying == true)
        {
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
}