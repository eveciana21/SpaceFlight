using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;


public class MainMenu : MonoBehaviour
{
    [SerializeField] private PlayableDirector _director;
    [SerializeField] private GameObject _controlsScreen;

    [SerializeField] private GameObject _playButton, _quitButton, _controlsButton;


    public void PressQuit()
    {
        _director.Play();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PressPlay()
    {
        SceneManager.LoadScene(1);
        Cursor.visible = false;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Controls()
    {
        _playButton.SetActive(false);
        _quitButton.SetActive(false);
        _controlsButton.SetActive(false);
        _controlsScreen.SetActive(true);

    }

    public void ExitControlsScreen()
    {
        _controlsScreen.SetActive(false);
        _playButton.SetActive(true);
        _quitButton.SetActive(true);
        _controlsButton.SetActive(true);
    }


}
