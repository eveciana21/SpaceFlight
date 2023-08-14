using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _satellitesRemaining = 5;
    [SerializeField] private GameObject _lastSatellite;
    private UIManager _uiManager;
    private ChangeCamera _changeCameraScript;

    private bool _canQuit;
    [SerializeField] private GameObject _canQuitUI;
    [SerializeField] private GameObject _satRemainingImage;

    [SerializeField] private Collider _portalCollider;
    [SerializeField] private GameObject _cutsceneText;
    [SerializeField] private GameObject _missionStatement;
    void Start()
    {
        _canQuitUI.SetActive(false);
        _lastSatellite.SetActive(false);

        _changeCameraScript = GameObject.Find("Cameras").GetComponent<ChangeCamera>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }

        SatelliteCount();
        SatelliteRemainingToEndGame();
    }

    public void SatelliteCutscene()
    {
        _satellitesRemaining = 0;
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
        _satRemainingImage.SetActive(false);
        _missionStatement.SetActive(false);
        _cutsceneText.SetActive(false);
        _changeCameraScript.IsPlayingCutScene();
        _canQuitUI.SetActive(true);
        _canQuit = true;
        Time.timeScale = 0;
    }

    public void Continue()
    {
        _satRemainingImage.SetActive(true);
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

    public void EnablePortalCollider()
    {
        _portalCollider.enabled = true;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
