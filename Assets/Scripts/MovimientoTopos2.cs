using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoTopos2 : MonoBehaviour
{
    public Transform[] topos;

    private float velocidad;
    
    public Vector3[] startPos;


    // Start is called before the first frame update
    void Start()
    {
        //la posicion de los topos
        velocidad = 7.5f;
        startPos[0] = topos[0].localPosition;
        startPos[1] = topos[1].localPosition;
        startPos[2] = topos[2].localPosition;
        startPos[3] = topos[3].localPosition;

    }

    // Update is called once per frame
    void Update()
    {
        //la posicion de los topos cambia 
        topos[0].localPosition = new Vector3(startPos[0].x, startPos[0].y + (Mathf.Sin(Time.time * 1.6f) * velocidad), startPos[0].z);
        topos[1].localPosition = new Vector3(startPos[1].x, startPos[1].y + (Mathf.Sin(Time.time * 1.6f) * velocidad), startPos[1].z);
        topos[2].localPosition = new Vector3(startPos[2].x, startPos[2].y + (Mathf.Sin(Time.time * 1.6f) * -velocidad), startPos[2].z);
        topos[3].localPosition = new Vector3(startPos[3].x, startPos[3].y + (Mathf.Sin(Time.time * 1.6f) * -velocidad), startPos[3].z);

    }


}
