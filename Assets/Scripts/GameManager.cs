using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    private bool _canQuit;
    [SerializeField] private GameObject _canQuitUI;

    void Start()
    {
        _canQuitUI.SetActive(false);
    }

    void Update()
    {
        Quit();
    }

    private void Quit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _canQuitUI.SetActive(true);
            _canQuit = true;
            Time.timeScale = 0;
        }
    }

    public void Continue()
    {
        _canQuitUI.SetActive(false);

        _canQuit = false;
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        if (_canQuit == true)
        {
            _canQuitUI.SetActive(false);
            SceneManager.LoadScene(0);
        }
    }
}
