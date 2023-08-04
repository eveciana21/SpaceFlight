using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private int _satellitesRemaining = 5;
    [SerializeField] private GameObject _lastSatellite;
    private UIManager _uiManager;
    private ChangeCamera _changeCameraScript;

    private bool _canQuit;
    [SerializeField] private GameObject _canQuitUI;
    [SerializeField] private GameObject _satRemainingImage;
    [SerializeField] private GameObject _satRemainingWindow;

    void Start()
    {
        _canQuitUI.SetActive(false);
        _lastSatellite.SetActive(false);

        _changeCameraScript = GameObject.Find("Cameras").GetComponent<ChangeCamera>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

    }

    void Update()
    {
        Quit();
        SatelliteCount();
        SatelliteRemainingToEndGame();
    }

    private void SatelliteRemainingToEndGame()
    {
        if (_satellitesRemaining == 1)
        {
            _lastSatellite.SetActive(true);
        }
        else if (_satellitesRemaining < 1)
        {
            _changeCameraScript.IsPlayingCutScene();
            _changeCameraScript.SatelliteImageDisabled();
        }
    }

    private void Quit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _changeCameraScript.IsPlayingCutScene();
            _canQuitUI.SetActive(true);
            _canQuit = true;
            Time.timeScale = 0;
        }
    }

    public void Continue()
    {
        _canQuitUI.SetActive(false);
        _changeCameraScript.IsNotPlayingCutScene();
        _canQuit = false;
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        if (_canQuit == true)
        {
            _canQuitUI.SetActive(false);
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }
    }

    public void SatellitesRemaining()
    {
        _satellitesRemaining--;
    }

    public void SatelliteCount()
    {
        _uiManager.SatellitesRemaining(_satellitesRemaining);
    }

}
