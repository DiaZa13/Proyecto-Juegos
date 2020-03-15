using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_Manager : MonoBehaviour
{
    public Button soundButton;
    public Sprite soundOff;
    public Sprite soundOn;
    private bool sound = true;
    private AudioSource audioSrc;


    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Level1()
    {
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

   
}
