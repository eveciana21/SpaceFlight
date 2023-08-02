using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : MonoBehaviour
{
    [SerializeField] private int _health = 16;
    [SerializeField] private GameObject _explosion;
    [SerializeField] private MeshRenderer _renderer;
    private bool _destroySeq;
    private GameManager _gameManager;

    void Start()
    {
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        transform.Rotate(new Vector3(0.1f, 0.1f, 0.1f));


        if (_health < 1 && _destroySeq == false)
        {
            StartCoroutine(DestroySatellite());
            _gameManager.SatellitesRemaining();
            _destroySeq = true;
        }
    }

    IEnumerator DestroySatellite()
    {
        GameObject explosion = Instantiate(_explosion, transform.position, Quaternion.identity);
        Destroy(explosion, 10f);
        yield return new WaitForSeconds(0.5f);
        _renderer.enabled = false;
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Laser")
        {
            Debug.Log("Hit Target");
            _health--;
            Destroy(other.gameObject);
        }
    }
}
