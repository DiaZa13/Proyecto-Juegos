using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Image pauseMenu;
    private bool isPaused = false;
    public Image instructions;
    private AudioSource audioSrc;
    private bool sound = true;
    public Text soundText;

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        audioSrc.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            activePausemenu();

        if (Input.anyKeyDown)
            instructions.gameObject.SetActive(false);

    }
    public void Resume()
    {

        if (pauseMenu) 
        {
            pauseMenu.gameObject.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }

    public void Reload()
    {
        pauseMenu.gameObject.SetActive(false);
        SceneManager.LoadScene("EscenaPrincipal");

    }

    public void Exit()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

#else
            Application.Quit();

#endif

    }

    public void activePausemenu()
    {
        if (isPaused)
        {
            if (pauseMenu) 
            {
                pauseMenu.gameObject.SetActive(false);
                Time.timeScale = 1.0f;
            }
        }
        else
        {
            if (pauseMenu) 
            {
                pauseMenu.gameObject.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }

        isPaused = !isPaused;
    }

    public void Volume()
    {
        if (sound == true)
        {
            audioSrc.Stop();
            soundText.text = "SONIDO: OFF";
            sound = !sound;
        }
        else
        {
            audioSrc.Play();
            soundText.text = "SONIDO: ON";
            sound = !sound;
        }
    }

    public void Instructions()
    {
        instructions.gameObject.SetActive(true);
    }


}

