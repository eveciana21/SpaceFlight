using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private PlayableDirector _director;
    void Start()
    {

    }


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
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
