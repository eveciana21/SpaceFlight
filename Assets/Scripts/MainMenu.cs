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


    public void PressPlay()
    {
        _director.Play();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
