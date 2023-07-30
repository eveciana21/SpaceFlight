using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControls : MonoBehaviour
{
    [SerializeField] private float _rotSpeed;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _currentSpeed;
    private float _vertical;
    private float _horizontal;
    [SerializeField] private float _maxRotate;
    [SerializeField] private GameObject _shipModel;
    [SerializeField] private GameObject _particle;
    [SerializeField] private bool _cockpitCam;
    [SerializeField] private GameObject _laserPrefab;

    [SerializeField] private AudioClip _laserAudio;
    private AudioSource _audioSource;



    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        if (_audioSource != null)
        {
            _audioSource.clip = _laserAudio;
        }

        _currentSpeed = 1;
        _particle.SetActive(false);
    }

    void Update()
    {
        ShipMovement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_laserPrefab, transform.position, transform.rotation);
            _audioSource.Play();

        }
    }

    private void ShipMovement()
    {
        _vertical = Input.GetAxis("Vertical");
        _horizontal = Input.GetAxis("Horizontal");

        if (_cockpitCam == false)
        {
            if (Input.GetKey(KeyCode.T))
            {
                _currentSpeed++;
                if (_currentSpeed > 12)
                {
                    _currentSpeed = 12;
                    _particle.SetActive(true);
                }
            }//increase speed
        }

        if (Input.GetKeyUp(KeyCode.T))
        {
            _currentSpeed = 1;
            _particle.SetActive(false);
        }

        if (Input.GetKey(KeyCode.G))
        {
            _currentSpeed--;
            if (_currentSpeed < 1)
            {
                _currentSpeed = 1;
            }
        }//decrease speed

        Vector3 rotateH = new Vector3(0, _horizontal, 0);
        transform.Rotate(rotateH * _rotSpeed * Time.deltaTime);

        Vector3 rotateV = new Vector3(_vertical, 0, 0);
        transform.Rotate(rotateV * _rotSpeed * Time.deltaTime);

        transform.Rotate(new Vector3(0, 0, -_horizontal * 0.2f), Space.Self);

        transform.position += transform.forward * _currentSpeed * Time.deltaTime;
    }

    

    public void CockpitCamActive()
    {
        _cockpitCam = true;
    }
    public void CockpitCamNotActive()
    {
        _cockpitCam = false;
    }
}
