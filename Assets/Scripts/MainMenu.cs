using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private PlayableDirector _director, _thumbsUpDirector;
    [SerializeField] private GameObject _controlsScreen;

    [SerializeField] private GameObject _playButton, _quitButton, _controlsButton;
    [SerializeField] private PlayableDirector _typingDirector;


    public void TypingLoopDirector()
    {
        _typingDirector.Play();
    }

    public void PressQuit()
    {
        _director.Play();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Controls()
    {
        _controlsScreen.SetActive(true);
    }

    public void ExitControlsScreen()
    {
        _controlsScreen.SetActive(false);
    }
}