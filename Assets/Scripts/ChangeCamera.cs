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

    private float _timeLapsed;
    void Start()
    {
        _cockpitCam.SetActive(false);
        _cockpit.SetActive(false);
    }

    void Update()
    {
       // _timeLapsed = Time.time + 5;

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
        else if (!Input.anyKey && _timeLapsed > 5)
        {
            Debug.Log("Its been 5 seconds");
            _director.Play();
        }
    }
}
