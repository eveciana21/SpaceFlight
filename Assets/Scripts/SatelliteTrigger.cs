using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SatelliteTrigger : MonoBehaviour
{
    [SerializeField] private PlayableDirector _satelliteDirector;
    [SerializeField] private GameObject _satelliteImage;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
    }

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
