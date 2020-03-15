using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public GameObject[] corazon;
    public int vida;
    public GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        //MC tiene 3 vidas al iniciar el juego
        vida = 3;
        corazon[0].gameObject.SetActive(true);
        corazon[1].gameObject.SetActive(true);
        corazon[2].gameObject.SetActive(true);

        gameOver.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (vida > 3)
        {
            vida = 3;
        }

        switch (vida)
        {
            //con 3 vidas se ven tods los corazones 
            case 3:
                corazon[0].gameObject.SetActive(true);
                corazon[1].gameObject.SetActive(true);
                corazon[2].gameObject.SetActive(true);
                break;
            //con 2 vidas se ven 2 corazones
            case 2:
                corazon[0].gameObject.SetActive(true);
                corazon[1].gameObject.SetActive(true);
                corazon[2].gameObject.SetActive(false);
                break;
            //con una vida se ve un corazon
            case 1:
                corazon[0].gameObject.SetActive(true);
                corazon[1].gameObject.SetActive(false);
                corazon[2].gameObject.SetActive(false);
                break;
            //con 0 vidas ya no hay corazones y se presenta la pantalla de GAME OVER
            case 0:
                corazon[0].gameObject.SetActive(false);
                corazon[1].gameObject.SetActive(false);
                corazon[2].gameObject.SetActive(false);

                gameOver.gameObject.SetActive(true);
                Time.timeScale = 0;
                break;

        }
    }
}
