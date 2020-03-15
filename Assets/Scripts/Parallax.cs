using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform camaraM;
    private Vector3 posicion;
    public Vector2 parallax;
   
   
    private float size;

    private void Start()
    {
        posicion = camaraM.position;
        Sprite sp = GetComponent<SpriteRenderer>().sprite;
        Texture2D t2d = sp.texture;
        size = t2d.width / sp.pixelsPerUnit; 
    }

    private void LateUpdate()
    {
        Vector3 movimiento = camaraM.position - posicion;
        transform.position += new Vector3(movimiento.x * parallax.x, movimiento.y * parallax.y, 0f);
        //se reinicia la posicion de la camara
        posicion = camaraM.position;

        if(Mathf.Abs(camaraM.position.x - transform.position.x) >= size)
        {
            
            //la camara cambia a una nueva posicion
            transform.position = new Vector3(camaraM.position.x, transform.position.y, 0f);
        }
    }
}
